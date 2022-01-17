namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContractHistoryRevertDrop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContractHistories", "Plan_Id", "dbo.Plans");
            DropIndex("dbo.ContractHistories", new[] { "Plan_Id" });
            RenameColumn(table: "dbo.ContractHistories", name: "Plan_Id", newName: "PlanId");
            AlterColumn("dbo.ContractHistories", "PlanId", c => c.Int(nullable: false));
            CreateIndex("dbo.ContractHistories", "PlanId");
            AddForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractHistories", "PlanId", "dbo.Plans");
            DropIndex("dbo.ContractHistories", new[] { "PlanId" });
            AlterColumn("dbo.ContractHistories", "PlanId", c => c.Int());
            RenameColumn(table: "dbo.ContractHistories", name: "PlanId", newName: "Plan_Id");
            CreateIndex("dbo.ContractHistories", "Plan_Id");
            AddForeignKey("dbo.ContractHistories", "Plan_Id", "dbo.Plans", "Id");
        }
    }
}
