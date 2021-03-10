namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUser", "LastName", c => c.String());
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
        }
    }
}
