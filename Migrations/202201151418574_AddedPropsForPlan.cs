namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropsForPlan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Plans", "Description", c => c.String());
            AddColumn("dbo.Plans", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Category");
            DropColumn("dbo.Plans", "Description");
            DropColumn("dbo.Plans", "Price");
        }
    }
}
