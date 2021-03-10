namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeItemsAccount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUser", "LastName", c => c.String());
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String());
            AlterColumn("dbo.ApplicationUser", "InsulinToCarbRatio", c => c.Double());
            AlterColumn("dbo.ApplicationUser", "CorrectionFactor", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUser", "CorrectionFactor", c => c.Double(nullable: false));
            AlterColumn("dbo.ApplicationUser", "InsulinToCarbRatio", c => c.Double(nullable: false));
            AlterColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
        }
    }
}
