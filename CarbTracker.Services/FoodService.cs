using CarbTracker.Data;
using CarbTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Services
{
    public class FoodService
    {
        public IEnumerable<FoodListItem> GetFood()
        {

            using (var context = new ApplicationDbContext())
            {
                if (context.Foods.Count() < 2)
                {
                    List<Food> seedFoods = new List<Food>();
                    seedFoods.Add(new Food("Cheese", 1, 1));
                    seedFoods.Add(new Food("Bread", 18, 1.25));
                    seedFoods.Add(new Food("Egg", 1, 2));
                    seedFoods.Add(new Food("Milk", 12, 8));
                    seedFoods.Add(new Food("Banana", 23, 4.5));
                    seedFoods.Add(new Food("Turkey", 1, 3));
                    seedFoods.Add(new Food("Apple", 10, 4));
                    seedFoods.Add(new Food("Lettuce", 0, 1));
                    seedFoods.Add(new Food("Tomato", 1, 1));
                    seedFoods.Add(new Food("bacon", 1, 0));
                    
                    foreach (var food in seedFoods)
                    {
                        context.Foods.Add(food);
                        context.SaveChanges();
                    }

                }
                var query = context.Foods
                                .Select(e => new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    Name = e.Name,
                                    Description = e.Description,
                                    ServingInOunces = e.ServingInOunces,
                                    Carbs = e.Carbs
                                }
                            ) ;

                return query.ToArray();
            }
        }
        public bool CreateFood(FoodCreate model)
        {
            var entity =
                new Food()
                {
                    FoodId = 2,
                    Name = model.Name,
                    Carbs = 50,
                    ServingInOunces = 1.0,
                    Description = model.Description
                };

            using (var context = new ApplicationDbContext())
            {
                context.Foods.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
