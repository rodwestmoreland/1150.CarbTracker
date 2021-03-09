namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BloodSugarTracker", "UserId", "dbo.UserTable");
            DropIndex("dbo.BloodSugarTracker", new[] { "UserId" });
            AddColumn("dbo.ApplicationUser", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "InsulinToCarbRatio", c => c.Double(nullable: false));
            AddColumn("dbo.ApplicationUser", "CorrectionFactor", c => c.Double(nullable: false));
            AddColumn("dbo.ApplicationUser", "Password", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            
        }
        
        public override void Down()
        {
            
            
            DropColumn("dbo.ApplicationUser", "CreatedAt");
            DropColumn("dbo.ApplicationUser", "Password");
            DropColumn("dbo.ApplicationUser", "CorrectionFactor");
            DropColumn("dbo.ApplicationUser", "InsulinToCarbRatio");
            DropColumn("dbo.ApplicationUser", "FirstName");
            DropColumn("dbo.ApplicationUser", "LastName");
            CreateIndex("dbo.BloodSugarTracker", "UserId");
            AddForeignKey("dbo.BloodSugarTracker", "UserId", "UserId", cascadeDelete: true);
        }
    }
}
