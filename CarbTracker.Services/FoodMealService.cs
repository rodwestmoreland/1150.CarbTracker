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

        public IEnumerable<FoodMealListItem> GetFoodMeal()
        {
            using (var context = new ApplicationDbContext())
            {
                if (context.FoodMeals.Count() < 2)
                {
                    List<FoodMeal> seedFoodMeals = new List<FoodMeal>();
                    // Cheese Sandwich
                    seedFoodMeals.Add(new FoodMeal(1 , 1));
                    seedFoodMeals.Add(new FoodMeal(2 , 1));
                    seedFoodMeals.Add(new FoodMeal(2 , 1));
                    // Omelet
                    seedFoodMeals.Add(new FoodMeal(3 , 2));
                    seedFoodMeals.Add(new FoodMeal(1 , 2));
                    // BLT
                    seedFoodMeals.Add(new FoodMeal(2 , 3));
                    seedFoodMeals.Add(new FoodMeal(2 , 3));
                    seedFoodMeals.Add(new FoodMeal(8 , 3)); 
                    seedFoodMeals.Add(new FoodMeal(9 , 3));
                    seedFoodMeals.Add(new FoodMeal(10 , 3));
                    // Turkey Sandwich
                    seedFoodMeals.Add(new FoodMeal(2 , 4));
                    seedFoodMeals.Add(new FoodMeal(2 , 4));
                    seedFoodMeals.Add(new FoodMeal(6 , 4));
                    // French Toast
                    seedFoodMeals.Add(new FoodMeal(2 , 5));
                    seedFoodMeals.Add(new FoodMeal(2 , 5));
                    seedFoodMeals.Add(new FoodMeal(3 , 5));
                    seedFoodMeals.Add(new FoodMeal(4 , 5));
                    // Banana Apple Salad
                    seedFoodMeals.Add(new FoodMeal(5 , 6));
                    seedFoodMeals.Add(new FoodMeal(7 , 6));
                    // Turkey Club
                    seedFoodMeals.Add(new FoodMeal(2 , 7));
                    seedFoodMeals.Add(new FoodMeal(2 , 7));
                    seedFoodMeals.Add(new FoodMeal(6 , 7));
                    seedFoodMeals.Add(new FoodMeal(7 , 7));
                    seedFoodMeals.Add(new FoodMeal(8 , 7));
                    seedFoodMeals.Add(new FoodMeal(9 , 7));
                    // Apple Banana Smoothie
                    seedFoodMeals.Add(new FoodMeal(4 , 8));
                    seedFoodMeals.Add(new FoodMeal(5 , 8));
                    seedFoodMeals.Add(new FoodMeal(7 , 8));


                    foreach (var foodMeal in seedFoodMeals)
                    {
                        context.FoodMeals.Add(foodMeal);
                        context.SaveChanges();
                    }
                }
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
