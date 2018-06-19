namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RSVPs", "AttendeeName", c => c.String());
            AlterColumn("dbo.Dinners", "HostedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dinners", "HostedBy", c => c.String(nullable: false));
            DropColumn("dbo.RSVPs", "AttendeeName");
        }
    }
}
