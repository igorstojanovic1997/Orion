namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeCreatedToContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "DateTimeCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contracts", "DateTimeCreated");
        }
    }
}
