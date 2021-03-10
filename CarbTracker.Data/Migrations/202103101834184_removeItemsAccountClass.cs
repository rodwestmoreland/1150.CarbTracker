namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeItemsAccountClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "Password");
            DropColumn("dbo.ApplicationUser", "CreatedAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.ApplicationUser", "Password", c => c.String(nullable: false));
        }
    }
}
