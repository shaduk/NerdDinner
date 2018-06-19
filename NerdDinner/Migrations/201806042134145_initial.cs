namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dinners", "Country", c => c.String());
            AlterColumn("dbo.Dinners", "Title", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Dinners", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Dinners", "HostedBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dinners", "HostedBy", c => c.String());
            AlterColumn("dbo.Dinners", "Address", c => c.String());
            AlterColumn("dbo.Dinners", "Title", c => c.String());
            DropColumn("dbo.Dinners", "Country");
        }
    }
}
