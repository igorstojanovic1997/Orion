namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contracts", "ContractTypeId", "dbo.ContractTypes");
            DropIndex("dbo.Contracts", new[] { "ContractTypeId" });
            CreateTable(
                "dbo.ContractPlans",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ContractId = c.Int(nullable: false),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.ContractId)
                .Index(t => t.PlanId);
            
            AddColumn("dbo.Contracts", "DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Contracts", "Fee", c => c.Short(nullable: false));
            AddColumn("dbo.Contracts", "GratisPeriod", c => c.Byte(nullable: false));
            AddColumn("dbo.Contracts", "Duration", c => c.Byte(nullable: false));
            DropColumn("dbo.Contracts", "ContractTypeId");
            DropTable("dbo.ContractTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ContractTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Duration = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        Fee = c.Short(nullable: false),
                        GratisPeriod = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contracts", "ContractTypeId", c => c.Byte(nullable: false));
            DropForeignKey("dbo.ContractPlans", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.ContractPlans", "ContractId", "dbo.Contracts");
            DropIndex("dbo.ContractPlans", new[] { "PlanId" });
            DropIndex("dbo.ContractPlans", new[] { "ContractId" });
            DropColumn("dbo.Contracts", "Duration");
            DropColumn("dbo.Contracts", "GratisPeriod");
            DropColumn("dbo.Contracts", "Fee");
            DropColumn("dbo.Contracts", "DiscountRate");
            DropTable("dbo.ContractPlans");
            CreateIndex("dbo.Contracts", "ContractTypeId");
            AddForeignKey("dbo.Contracts", "ContractTypeId", "dbo.ContractTypes", "Id", cascadeDelete: true);
        }
    }
}
