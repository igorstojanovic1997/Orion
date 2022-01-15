namespace Orion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePlans : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Plans (Name, Price, Description, Category) VALUES ('Internet', 1500, 'Internet paket brzine do 100 Mbps', 0)");
            Sql("INSERT INTO Plans (Name, Price, Description, Category) VALUES ('IPTV Sport', 450, 'Sportski kanali, Arena, SportKlub, Euro Sport', 1)");
        }
        
        public override void Down()
        {
        }
    }
}
