using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CarbTracker.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false){}
        
        public DbSet<BloodSugarTracker> BloodSugarTrackers  { get; set; }
        public DbSet<FoodMeal>          FoodMeals           { get; set; }
        public DbSet<Food>              Foods               { get; set; }
        public DbSet<MealTable>         MealTables          { get; set; }
        public DbSet<UserTable>         UserTabeles         { get; set; }

        public static ApplicationDbContext Create() => new ApplicationDbContext();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                        .Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations
                        .Add(new IdentityUserLoginConfiguration())
                        .Add(new IdentityUserRoleConfiguration());
        }
    } // \ApplicationDBContext



    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration() => HasKey(iul => iul.UserId);
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration() => HasKey(iur => iur.UserId);
    }

}