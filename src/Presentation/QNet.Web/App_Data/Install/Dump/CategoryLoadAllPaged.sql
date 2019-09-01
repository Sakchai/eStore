CREATE PROCEDURE `CategoryLoadAllPaged` (
 p_ShowHidden         TINYINT /* = 0 */,
    p_Name               LONGTEXT /* = NULL */,
    p_StoreId            INT /* = 0 */,
    p_CustomerRoleIds	LONGTEXT /* = NULL */,
    p_PageIndex			INT /* = 0 */,
	p_PageSize			INT /* = 2147483644 */,
    OUT p_TotalRecords 		INT /* = NULL */ 
)
BEGIN
 DECLARE v_start,v_end,v_lengthId,v_lengthOrder,v_FilteredCustomerRoleIdsCount INT; 
    
    SET v_start = 1, v_end = CHARINDEX(',', p_CustomerRoleIds);
    
    -- filter by customer role IDs (access control list)
	SET p_CustomerRoleIds = IFNULL(p_CustomerRoleIds, '');
    
	CREATE TEMPORARY TABLE tmpFilteredCustomerRoleIds
	(
		CustomerRoleId INT NOT NULL
	);

    WHILE (v_start < CHAR_LENGTH(RTRIM(p_CustomerRoleIds)) + 1) DO
        IF v_end = 0 THEN 
            SET v_end = CHAR_LENGTH(RTRIM(p_CustomerRoleIds)) + 1;
        END IF;

        INSERT INTO tmpFilteredCustomerRoleIds (CustomerRoleId)
        VALUES(SUBSTRING(p_CustomerRoleIds, v_start, v_end - v_start));
        SET v_start = v_end + 1;
        SET v_end = CHARINDEX(',', p_CustomerRoleIds, v_start);
    END WHILE;
	
	SELECT COUNT(1)
	INTO v_FilteredCustomerRoleIdsCount FROM
    tmpFilteredCustomerRoleIds;
    -- ordered categories
    CREATE TEMPORARY TABLE tmpOrderedCategoryIds
	(
		Id int AUTO_INCREMENT  NOT NULL,
		CategoryId int NOT NULL
	);
    
    -- get max length of DisplayOrder and Id columns (used for padding Order column)
	SELECT 
    CHAR_LENGTH(RTRIM(MAX(Id)))
	INTO v_lengthId FROM
    Category;
	
	SELECT 
    CHAR_LENGTH(RTRIM(MAX(DisplayOrder)))
	INTO v_lengthOrder FROM
    Category;
	
	SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED ;
    -- get category tree
    WITH 
    CategoryTree AS (SELECT Category.Id AS Id, 
						(select RIGHT(REPLICATE('0', v_lengthOrder)+ RTRIM(CAST(Category.DisplayOrder AS LONGTEXT)), v_lengthOrder)) + '-' + (select RIGHT(REPLICATE('0', v_lengthId)+ RTRIM(CAST(Category.Id AS LONGTEXT)), v_lengthId))  AS Order
							FROM Category WHERE Category.ParentCategoryId = 0
						UNION ALL
						 SELECT Category.Id AS [Id], 
							CONCAT(CategoryTree.Order , '|' , (select RIGHT(REPLICATE('0', v_lengthOrder)+ RTRIM(CAST(Category.DisplayOrder AS LONGTEXT)), v_lengthOrder)) + '-' + (select RIGHT(REPLICATE('0', v_lengthId)+ RTRIM(CAST(Category.Id AS LONGTEXT)), v_lengthId)))  AS [Order]
						FROM Category
					INNER JOIN [CategoryTree] ON CategoryTree.Id = Category.ParentCategoryId)
		
    INSERT INTO tmpOrderedCategoryIds (CategoryId)
    SELECT Category.Id
    FROM CategoryTree
    RIGHT JOIN [Category] ON CategoryTree.Id = Category.Id
    WHERE Category.Deleted = 0
    AND (p_ShowHidden = 1 OR Category.Published = 1)
    AND (p_Name IS NULL OR p_Name = '' OR Category.Name LIKE ('%' + CONCAT(p_Name , '%')))
    AND (p_ShowHidden = 1 OR v_FilteredCustomerRoleIdsCount  = 0 OR Category.SubjectToAcl = 0
        OR EXISTS (SELECT 1 
					FROM tmpFilteredCustomerRoleIds roles 
					WHERE roles.CustomerRoleId IN
						(SELECT acl.CustomerRoleId FROM AclRecord acl  
						WHERE acl.EntityId = Category.Id AND acl.EntityName = 'Category')
        )
    )
    AND (p_StoreId = 0 OR Category.LimitedToStores = 0
        OR EXISTS (SELECT 1 FROM StoreMapping sm
			WHERE sm.EntityId = Category.Id AND sm.EntityName = 'Category' 
            AND sm.StoreId = p_StoreId
		)
    )
    ORDER BY IFNULL(CategoryTree.Order, 1)
	
	SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ ;
	 
    -- total records
    SET p_TotalRecords = FOUND_ROWS();

    -- paging
    SELECT Category.* FROM tmpOrderedCategoryIds AS Result 
    INNER JOIN Category ON [Result].[CategoryId] = Category.Id
    WHERE (Result.Id > p_PageSize * p_PageIndex 
    AND Result.Id <= p_PageSize * (p_PageIndex + 1))
    ORDER BY Result.Id;

    DROP TABLE tmpFilteredCustomerRoleIds;
    DROP TABLE tmpOrderedCategoryIds;
END