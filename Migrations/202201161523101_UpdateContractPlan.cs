namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContractPlan : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ContractPlans");
            AlterColumn("dbo.ContractPlans", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ContractPlans", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ContractPlans");
            AlterColumn("dbo.ContractPlans", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.ContractPlans", "Id");
        }
    }
}
