namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContractHistoryDropPlanId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans");
            DropIndex("dbo.ContractHistories", new[] { "PlanId" });
            RenameColumn(table: "dbo.ContractHistories", name: "PlanId", newName: "Plan_Id");
            AlterColumn("dbo.ContractHistories", "Plan_Id", c => c.Int());
            CreateIndex("dbo.ContractHistories", "Plan_Id");
            AddForeignKey("dbo.ContractHistories", "Plan_Id", "dbo.Plans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractHistories", "Plan_Id", "dbo.Plans");
            DropIndex("dbo.ContractHistories", new[] { "Plan_Id" });
            AlterColumn("dbo.ContractHistories", "Plan_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ContractHistories", name: "Plan_Id", newName: "PlanId");
            CreateIndex("dbo.ContractHistories", "PlanId");
            AddForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
    }
}
