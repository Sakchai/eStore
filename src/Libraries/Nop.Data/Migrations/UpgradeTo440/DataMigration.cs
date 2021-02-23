﻿using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Security;
using Nop.Core.Domain.Vendors;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.UpgradeTo440
{
    [NopMigration("2020-06-10 00:00:00", "4.40.0", UpdateMigrationType.Data)]
    [SkipMigrationOnInstall]
    public class DataMigration : Migration
    {
        private readonly INopDataProvider _dataProvider;

        public DataMigration(INopDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            // new permission
            if (!_dataProvider.GetTable<PermissionRecord>().Any(pr => string.Compare(pr.SystemName, "AccessProfiling", true) == 0))
            {
                var profilingPermission = _dataProvider.InsertEntity(
                    new PermissionRecord
                    {
                        Name = "Public store. Access MiniProfiler results",
                        SystemName = "AccessProfiling",
                        Category = "PublicStore"
                    }
                );

                //add it to the Admin role by default
                var adminRole = _dataProvider
                    .GetTable<CustomerRole>()
                    .FirstOrDefault(x => x.IsSystemRole && x.SystemName == NopCustomerDefaults.AdministratorsRoleName);

                _dataProvider.InsertEntity(
                    new PermissionRecordCustomerRoleMapping
                    {
                        CustomerRoleId = adminRole.Id,
                        PermissionRecordId = profilingPermission.Id
                    }
                );
            }

            var activityLogTypeTable = _dataProvider.GetTable<ActivityLogType>();

            if (!activityLogTypeTable.Any(alt => string.Compare(alt.SystemKeyword, "AddNewSpecAttributeGroup", true) == 0))
                _dataProvider.InsertEntity(
                    new ActivityLogType
                    {
                        SystemKeyword = "AddNewSpecAttributeGroup",
                        Enabled = true,
                        Name = "Add a new specification attribute group"
                    }
                );

            if (!activityLogTypeTable.Any(alt => string.Compare(alt.SystemKeyword, "EditSpecAttributeGroup", true) == 0))
                _dataProvider.InsertEntity(
                    new ActivityLogType
                    {
                        SystemKeyword = "EditSpecAttributeGroup",
                        Enabled = true,
                        Name = "Edit a specification attribute group"
                    }
                );

            if (!activityLogTypeTable.Any(alt => string.Compare(alt.SystemKeyword, "DeleteSpecAttributeGroup", true) == 0))
                _dataProvider.InsertEntity(
                    new ActivityLogType
                    {
                        SystemKeyword = "DeleteSpecAttributeGroup",
                        Enabled = true,
                        Name = "Delete a specification attribute group"
                    }
                );
            //<MFA #475>
            if (!_dataProvider.GetTable<PermissionRecord>().Any(pr => string.Compare(pr.SystemName, "ManageMultifactorAuthenticationMethods", true) == 0))
            {
                var multiFactorAuthenticationPermission = _dataProvider.InsertEntity(
                    new PermissionRecord
                    {
                        Name = "Admin area. Manage Multi-factor Authentication Methods",
                        SystemName = "ManageMultifactorAuthenticationMethods",
                        Category = "Configuration"
                    }
                );

                //add it to the Admin role by default
                var adminRole = _dataProvider
                    .GetTable<CustomerRole>()
                    .FirstOrDefault(x => x.IsSystemRole && x.SystemName == NopCustomerDefaults.AdministratorsRoleName);

                _dataProvider.InsertEntity(
                    new PermissionRecordCustomerRoleMapping
                    {
                        CustomerRoleId = adminRole.Id,
                        PermissionRecordId = multiFactorAuthenticationPermission.Id
                    }
                );
            }
            //</MFA #475>

            //issue-3852
            var tableName = nameof(RewardPointsHistory);
            var rph = Schema.Table(tableName);
            var columnName = "UsedWithOrder_Id";

            if (rph.Column(columnName).Exists())
            {
                var constraintName = "RewardPointsHistory_UsedWithOrder";

                if (rph.Constraint(constraintName).Exists())
                    Delete.UniqueConstraint(constraintName).FromTable(tableName);

                Delete.Column(columnName).FromTable(tableName);
            }

            //#3353
            var productAttributeCombinationTableName = NameCompatibilityManager.GetTableName(typeof(ProductAttributeCombination));

            //add column
            if (!Schema.Table(productAttributeCombinationTableName).Column(nameof(ProductAttributeCombination.MinStockQuantity)).Exists())
            {
                Alter.Table(productAttributeCombinationTableName)
                    .AddColumn(nameof(ProductAttributeCombination.MinStockQuantity)).AsInt32().NotNullable().SetExistingRowsTo(0);
            }

            //#276 AJAX filters
            var categoryTableName = NameCompatibilityManager.GetTableName(typeof(Category));
            var manufacturerTableName = NameCompatibilityManager.GetTableName(typeof(Manufacturer));
            var vendorTableName = NameCompatibilityManager.GetTableName(typeof(Vendor));
            
            //remove column
            var priceRangesColumnName = "PriceRanges";

            if (Schema.Table(categoryTableName).Column(priceRangesColumnName).Exists())
                Delete.Column(priceRangesColumnName).FromTable(categoryTableName);

            if (Schema.Table(manufacturerTableName).Column(priceRangesColumnName).Exists())
                Delete.Column(priceRangesColumnName).FromTable(manufacturerTableName);

            //add column
            var priceRangeFilteringColumnName = "PriceRangeFiltering";

            if (!Schema.Table(categoryTableName).Column(priceRangeFilteringColumnName).Exists())
            {
                Alter.Table(categoryTableName)
                    .AddColumn(priceRangeFilteringColumnName).AsBoolean().NotNullable().SetExistingRowsTo(true);
            }
            
            if (!Schema.Table(manufacturerTableName).Column(priceRangeFilteringColumnName).Exists())
            {
                Alter.Table(manufacturerTableName)
                    .AddColumn(priceRangeFilteringColumnName).AsBoolean().NotNullable().SetExistingRowsTo(true);
            }

            if (!Schema.Table(vendorTableName).Column(priceRangeFilteringColumnName).Exists())
            {
                Alter.Table(vendorTableName)
                    .AddColumn(priceRangeFilteringColumnName).AsBoolean().NotNullable().SetExistingRowsTo(true);
            }

            //add column
            var priceFromColumnName = "PriceFrom";

            if (!Schema.Table(categoryTableName).Column(priceFromColumnName).Exists())
            {
                Alter.Table(categoryTableName)
                    .AddColumn(priceFromColumnName).AsDecimal().NotNullable().SetExistingRowsTo(0);
            }

            if (!Schema.Table(manufacturerTableName).Column(priceFromColumnName).Exists())
            {
                Alter.Table(manufacturerTableName)
                    .AddColumn(priceFromColumnName).AsDecimal().NotNullable().SetExistingRowsTo(0);
            }

            if (!Schema.Table(vendorTableName).Column(priceFromColumnName).Exists())
            {
                Alter.Table(vendorTableName)
                    .AddColumn(priceFromColumnName).AsDecimal().NotNullable().SetExistingRowsTo(0);
            }

            //add column
            var priceToColumnName = "PriceTo";

            if (!Schema.Table(categoryTableName).Column(priceToColumnName).Exists())
            {
                Alter.Table(categoryTableName)
                    .AddColumn(priceToColumnName).AsDecimal().NotNullable().SetExistingRowsTo(10000);
            }

            if (!Schema.Table(manufacturerTableName).Column(priceToColumnName).Exists())
            {
                Alter.Table(manufacturerTableName)
                    .AddColumn(priceToColumnName).AsDecimal().NotNullable().SetExistingRowsTo(10000);
            }

            if (!Schema.Table(vendorTableName).Column(priceToColumnName).Exists())
            {
                Alter.Table(vendorTableName)
                    .AddColumn(priceToColumnName).AsDecimal().NotNullable().SetExistingRowsTo(10000);
            }

            //add column
            var automaticallyCalculatePriceRangeColumnName = "AutomaticallyCalculatePriceRange";

            if (!Schema.Table(categoryTableName).Column(automaticallyCalculatePriceRangeColumnName).Exists())
            {
                Alter.Table(categoryTableName)
                    .AddColumn(automaticallyCalculatePriceRangeColumnName).AsBoolean().NotNullable().SetExistingRowsTo(true);
            }

            if (!Schema.Table(manufacturerTableName).Column(automaticallyCalculatePriceRangeColumnName).Exists())
            {
                Alter.Table(manufacturerTableName)
                    .AddColumn(automaticallyCalculatePriceRangeColumnName).AsBoolean().NotNullable().SetExistingRowsTo(true);
            }

            if (!Schema.Table(vendorTableName).Column(automaticallyCalculatePriceRangeColumnName).Exists())
            {
                Alter.Table(vendorTableName)
                    .AddColumn(automaticallyCalculatePriceRangeColumnName).AsBoolean().NotNullable().SetExistingRowsTo(true);
            }
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
