namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedlatitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dinners", "Description", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Dinners", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Dinners", "Longitude", c => c.Single(nullable: false));
            AlterColumn("dbo.Dinners", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dinners", "Address", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Dinners", "Longitude");
            DropColumn("dbo.Dinners", "Latitude");
            DropColumn("dbo.Dinners", "Description");
        }
    }
}
