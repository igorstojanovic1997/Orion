namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContractPlanModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "Username", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "Username", c => c.String(nullable: false));
        }
    }
}
