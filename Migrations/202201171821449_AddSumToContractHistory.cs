namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSumToContractHistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans");
            DropIndex("dbo.ContractHistories", new[] { "PlanId" });
            AddColumn("dbo.ContractHistories", "Sum", c => c.Single(nullable: false));
            DropColumn("dbo.ContractHistories", "PlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContractHistories", "PlanId", c => c.Int(nullable: false));
            DropColumn("dbo.ContractHistories", "Sum");
            CreateIndex("dbo.ContractHistories", "PlanId");
            AddForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
    }
}
