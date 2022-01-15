using System.Web.UI.WebControls;

namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateContractType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ContractTypes (Id, Duration, DiscountRate, Fee, GratisPeriod) VALUES (1, 12, 0, 2500, 3 )");
            Sql("INSERT INTO ContractTypes (Id, Duration, DiscountRate, Fee, GratisPeriod) VALUES (2, 24, 10, 2250, 6 )");
        }
        
        public override void Down()
        {
        }
    }
}
