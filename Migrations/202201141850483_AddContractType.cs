namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContractType : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.Contracts", "ContractTypeId");
            AddForeignKey("dbo.Contracts", "ContractTypeId", "dbo.ContractTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "ContractTypeId", "dbo.ContractTypes");
            DropIndex("dbo.Contracts", new[] { "ContractTypeId" });
            DropColumn("dbo.Contracts", "ContractTypeId");
            DropTable("dbo.ContractTypes");
        }
    }
}
