namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPropNameForContract : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Contracts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Contracts", "Username");
        }
    }
}
