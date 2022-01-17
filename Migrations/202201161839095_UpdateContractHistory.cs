namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContractHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractHistories", "PlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContractHistories", "PlanId");
            AddForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans");
            DropIndex("dbo.ContractHistories", new[] { "PlanId" });
            DropColumn("dbo.ContractHistories", "PlanId");
        }
    }
}
