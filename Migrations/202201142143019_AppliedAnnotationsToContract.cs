namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppliedAnnotationsToContract : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "Name", c => c.String());
        }
    }
}
