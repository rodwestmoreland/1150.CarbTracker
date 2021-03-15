namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey( "dbo.FoodMeal");
            DropColumn(     "dbo.FoodMeal", "FoodMeadId");
            AddColumn(      "dbo.FoodMeal", "FoodMealId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey(  "dbo.FoodMeal", "FoodMealId");
            
        }
        
        //public override void Down()
        //{
        //    AddColumn("dbo.FoodMeal", "FoodMeadId", c => c.Int(nullable: false, identity: true));
        //    DropPrimaryKey("dbo.FoodMeal");
        //    DropColumn("dbo.FoodMeal", "FoodMealId");
        //    AddPrimaryKey("dbo.FoodMeal", "FoodMeadId");
        //}
    }
}
