namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUser", "InsulinToCarbRatio", c => c.Double());
            AlterColumn("dbo.ApplicationUser", "CorrectionFactor", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUser", "CorrectionFactor", c => c.Double(nullable: false));
            AlterColumn("dbo.ApplicationUser", "InsulinToCarbRatio", c => c.Double(nullable: false));
        }
    }
}
