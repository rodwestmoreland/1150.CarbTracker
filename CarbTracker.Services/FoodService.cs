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
                    seedFoods.Add(new Food("Large Egg", 1, 2.25));
                    seedFoods.Add(new Food("Banana", 23, 4.5));
                    seedFoods.Add(new Food("Shredded Cheddar Cheese", 1, 4.0));
                    seedFoods.Add(new Food("Slice of Whole Grain Toast", 18, 1.25));
                    seedFoods.Add(new Food("8 oz Glass of Milk", 12, 8.0));
                    seedFoods.Add(new Food("8 oz Apple Juice", 28, 8.0));
                    seedFoods.Add(new Food("Sliced Turkey Sandwich", 35, 5.0));
                    seedFoods.Add(new Food("Small Bag of Cheetos", 13, 8.5));
                    seedFoods.Add(new Food("Can of Cherry Coke", 42, 12.0));
                    seedFoods.Add(new Food("Can of Coca Cola", 65, 12.0));
                    seedFoods.Add(new Food("Large Snickers Bar", 28, 2.0));

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
