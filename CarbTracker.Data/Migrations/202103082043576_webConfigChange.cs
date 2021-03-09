namespace CarbTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webConfigChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodSugarTracker",
                c => new
                    {
                        BSLevelId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        BSLevel = c.Int(nullable: false),
                        CarbsConsumed = c.Int(nullable: false),
                        CurrentWeight = c.Int(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.BSLevelId)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTable",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        InsulinToCarbRatio = c.Double(nullable: false),
                        CorrectionFactor = c.Double(nullable: false),
                        Password = c.String(nullable: false),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.FoodMeal",
                c => new
                    {
                        FoodMeadId = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodMeadId)
                .ForeignKey("dbo.Food", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.MealTable", t => t.MealId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.MealId);
            
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Carbs = c.Int(nullable: false),
                        ServingInOunces = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.MealTable",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        MealName = c.String(nullable: false),
                        TotalCarbs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("dbo.UserTable", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FoodMeal", "MealId", "dbo.MealTable");
            DropForeignKey("dbo.MealTable", "UserId", "dbo.UserTable");
            DropForeignKey("dbo.FoodMeal", "FoodId", "dbo.Food");
            DropForeignKey("dbo.BloodSugarTracker", "UserId", "dbo.UserTable");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.MealTable", new[] { "UserId" });
            DropIndex("dbo.FoodMeal", new[] { "MealId" });
            DropIndex("dbo.FoodMeal", new[] { "FoodId" });
            DropIndex("dbo.BloodSugarTracker", new[] { "UserId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.MealTable");
            DropTable("dbo.Food");
            DropTable("dbo.FoodMeal");
            DropTable("dbo.UserTable");
            DropTable("dbo.BloodSugarTracker");
        }
    }
}
