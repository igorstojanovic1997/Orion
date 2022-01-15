namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedContractHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateTimeUpdated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContractHistories", "ContractId", "dbo.Contracts");
            DropIndex("dbo.ContractHistories", new[] { "ContractId" });
            DropTable("dbo.ContractHistories");
        }
    }
}
