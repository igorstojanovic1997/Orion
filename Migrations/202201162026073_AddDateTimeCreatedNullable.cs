namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeCreatedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "DateTimeCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contracts", "DateTimeCreated", c => c.DateTime(nullable: false));
        }
    }
}
