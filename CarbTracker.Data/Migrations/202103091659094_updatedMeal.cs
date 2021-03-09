namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMeal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MealTable", "TotalCarbs", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MealTable", "TotalCarbs", c => c.Int(nullable: false));
        }
    }
}
