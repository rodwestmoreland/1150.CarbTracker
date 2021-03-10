using CarbTracker.Data;
using CarbTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Services
{
    public class FoodMealService
    {
/*        private readonly int _foodId;
        private readonly int _mealId;
        public FoodMealService(int foodId, int mealId)
        {
            _foodId = foodId;
            _mealId = mealId;
        }*/

        public IEnumerable<FoodMealListItem> GetFoodMeal()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.FoodMeals
                    .Select(e => new FoodMealListItem
                    {
                        FoodId = e.FoodId,
                        MealId = e.MealId
                    });
                
                return query.ToArray();
            }
        }

        public bool CreateFoodMeal(FoodMealCreate model)
        {
            var entity = new FoodMeal()
            {
                FoodId = model.FoodId,
                MealId = model.MealId,
            };
            using (var context = new ApplicationDbContext())
            {
                context.FoodMeals.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
