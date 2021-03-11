namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class associateUIDs2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BloodSugarTracker", "Id", c => c.String(maxLength: 128));
            AddColumn("dbo.MealTable", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.BloodSugarTracker", "Id");
            CreateIndex("dbo.MealTable", "Id");
            AddForeignKey("dbo.BloodSugarTracker", "Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.MealTable", "Id", "dbo.ApplicationUser", "Id");
            DropColumn("dbo.BloodSugarTracker", "UserId");
            DropColumn("dbo.BloodSugarTracker", "CurrentWeight");
            DropColumn("dbo.BloodSugarTracker", "CreatedAt");
            DropColumn("dbo.MealTable", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MealTable", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.BloodSugarTracker", "CreatedAt", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.BloodSugarTracker", "CurrentWeight", c => c.Int(nullable: false));
            AddColumn("dbo.BloodSugarTracker", "UserId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.MealTable", "Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.BloodSugarTracker", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.MealTable", new[] { "Id" });
            DropIndex("dbo.BloodSugarTracker", new[] { "Id" });
            DropColumn("dbo.MealTable", "Id");
            DropColumn("dbo.BloodSugarTracker", "Id");
        }
    }
}
