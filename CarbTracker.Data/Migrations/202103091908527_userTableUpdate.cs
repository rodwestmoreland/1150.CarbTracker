namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MealTable", "UserId", "dbo.UserTable");
            DropIndex("dbo.MealTable", new[] { "UserId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MealTable", "UserId");
            AddForeignKey("dbo.MealTable", "UserId", "dbo.UserTable", "UserId", cascadeDelete: true);
        }
    }
}
