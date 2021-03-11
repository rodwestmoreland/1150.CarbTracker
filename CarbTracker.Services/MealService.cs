using CarbTracker.Data;
using CarbTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Services
{
    public class MealService
    {
        private readonly string _userId;
        public MealService(string userId)
        {
            _userId = userId;
        }


        public IEnumerable<MealTableListItem> GetMeal()
        {


            //
            //    if (context.MealTables.Count() < 2)
            //    {
            //        List<MealTable> seedMeals = new List<MealTable>();
            //        seedMeals.Add(new MealTable();
            //        seedMeals.Add(new Food("Banana", 23, 4.5));
            //        seedMeals.Add(new Food("Shredded Cheddar Cheese", 1, 4.0));
            //        seedMeals.Add(new Food("Slice of Whole Grain Toast", 18, 1.25));
            //        seedMeals.Add(new Food("8 oz Glass of Milk", 12, 8.0));
            //        seedMeals.Add(new Food("8 oz Apple Juice", 28, 8.0));
            //        seedMeals.Add(new Food("Sliced Turkey Sandwich", 35, 5.0));
            //        seedMeals.Add(new Food("Small Bag of Cheetos", 13, 8.5));
            //        seedMeals.Add(new Food("Can of Cherry Coke", 42, 12.0));
            //        seedMeals.Add(new Food("Can of Coca Cola", 65, 12.0));
            //        seedMeals.Add(new Food("Large Snickers Bar", 28, 2.0));

            //        foreach (var meals in seedMeals)
            //        {
            //            context.MealTables.Add(meals);
            //            context.SaveChanges();
            //        }

            



                using (var context = new ApplicationDbContext())
            {
                var query = context.MealTables
                                .Select(e => new MealTableListItem
                                {
                                    MealId = e.MealId,
                                    MealName = e.MealName,
                                    TotalCarbs = e.TotalCarbs,
                                    Id = _userId
                                }
                            );

                return query.ToArray();
            }
        }

        public bool CreateMeal(MealTableCreate model)
        {
            
            var entity = new MealTable()
            {
                MealName = model.MealName,
                TotalCarbs = model.TotalCarbs,
                Id = _userId
            };

            using (var context = new ApplicationDbContext())
            {
                context.MealTables.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
