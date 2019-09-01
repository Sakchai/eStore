-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: gnet
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CategoryTemplateId` int(11) NOT NULL,
  `MetaKeywords` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `MetaDescription` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MetaTitle` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ParentCategoryId` int(11) NOT NULL,
  `PictureId` int(11) NOT NULL,
  `PageSize` int(11) NOT NULL,
  `AllowCustomersToSelectPageSize` bit(1) NOT NULL,
  `PageSizeOptions` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `PriceRanges` varchar(400) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ShowOnHomepage` bit(1) NOT NULL,
  `IncludeInTopMenu` bit(1) NOT NULL,
  `SubjectToAcl` bit(1) NOT NULL,
  `LimitedToStores` bit(1) NOT NULL,
  `Published` bit(1) NOT NULL,
  `Deleted` bit(1) NOT NULL,
  `DisplayOrder` int(11) NOT NULL,
  `CreatedOnUtc` datetime(6) NOT NULL,
  `UpdatedOnUtc` datetime(6) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Category_DisplayOrder` (`DisplayOrder`),
  KEY `IX_Category_ParentCategoryId` (`ParentCategoryId`),
  KEY `IX_Category_LimitedToStores` (`LimitedToStores`),
  KEY `IX_Category_SubjectToAcl` (`SubjectToAcl`),
  KEY `IX_Category_Deleted_Extended` (`Deleted`,`Id`,`Name`(255),`SubjectToAcl`,`LimitedToStores`,`Published`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Computers',NULL,1,NULL,NULL,NULL,0,1,6,1,'6, 3, 9',NULL,0,1,0,0,1,0,1,'2019-08-23 05:43:59.397100','2019-08-23 05:43:59.397200'),(2,'Desktops',NULL,1,NULL,NULL,NULL,1,2,6,1,'6, 3, 9','-1000;1000-1200;1200-;',0,1,0,0,1,0,1,'2019-08-23 05:43:59.718695','2019-08-23 05:43:59.718695'),(3,'Notebooks',NULL,1,NULL,NULL,NULL,1,3,6,1,'6, 3, 9',NULL,0,1,0,0,1,0,2,'2019-08-23 05:43:59.884946','2019-08-23 05:43:59.884946'),(4,'Software',NULL,1,NULL,NULL,NULL,1,4,6,1,'6, 3, 9',NULL,0,1,0,0,1,0,3,'2019-08-23 05:44:00.038503','2019-08-23 05:44:00.038503'),(5,'Electronics',NULL,1,NULL,NULL,NULL,0,5,6,1,'6, 3, 9',NULL,1,1,0,0,1,0,2,'2019-08-23 05:44:00.203143','2019-08-23 05:44:00.203143'),(6,'Camera & photo',NULL,1,NULL,NULL,NULL,5,6,6,1,'6, 3, 9','-500;500-;',0,1,0,0,1,0,1,'2019-08-23 05:44:00.345442','2019-08-23 05:44:00.345442'),(7,'Cell phones',NULL,1,NULL,NULL,NULL,5,7,6,1,'6, 3, 9',NULL,0,1,0,0,1,0,2,'2019-08-23 05:44:00.520693','2019-08-23 05:44:00.520693'),(8,'Others',NULL,1,NULL,NULL,NULL,5,8,6,1,'6, 3, 9','-100;100-;',0,1,0,0,1,0,3,'2019-08-23 05:44:00.685330','2019-08-23 05:44:00.685330'),(9,'Apparel',NULL,1,NULL,NULL,NULL,0,9,6,1,'6, 3, 9',NULL,1,1,0,0,1,0,3,'2019-08-23 05:44:00.848134','2019-08-23 05:44:00.848134'),(10,'Shoes',NULL,1,NULL,NULL,NULL,9,10,6,1,'6, 3, 9','-500;500-;',0,1,0,0,1,0,1,'2019-08-23 05:44:01.043055','2019-08-23 05:44:01.043055'),(11,'Clothing',NULL,1,NULL,NULL,NULL,9,11,6,1,'6, 3, 9',NULL,0,1,0,0,1,0,2,'2019-08-23 05:44:01.234815','2019-08-23 05:44:01.234815'),(12,'Accessories',NULL,1,NULL,NULL,NULL,9,12,6,1,'6, 3, 9','-100;100-;',0,1,0,0,1,0,3,'2019-08-23 05:44:01.395673','2019-08-23 05:44:01.395673'),(13,'Digital downloads',NULL,1,NULL,NULL,NULL,0,13,6,1,'6, 3, 9',NULL,1,1,0,0,1,0,4,'2019-08-23 05:44:01.650342','2019-08-23 05:44:01.650342'),(14,'Books',NULL,1,'Books, Dictionary, Textbooks','Books category description',NULL,0,14,6,1,'6, 3, 9','-25;25-50;50-;',0,1,0,0,1,0,5,'2019-08-23 05:44:01.841897','2019-08-23 05:44:01.841897'),(15,'Jewelry',NULL,1,NULL,NULL,NULL,0,15,6,1,'6, 3, 9','0-500;500-700;700-3000;',0,1,0,0,1,0,6,'2019-08-23 05:44:02.039755','2019-08-23 05:44:02.039755'),(16,'Gift Cards',NULL,1,NULL,NULL,NULL,0,16,6,1,'6, 3, 9',NULL,0,1,0,0,1,0,7,'2019-08-23 05:44:02.274157','2019-08-23 05:44:02.274157');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-08-31 12:15:19
