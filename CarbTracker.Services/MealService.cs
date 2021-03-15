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
                using (var context = new ApplicationDbContext())
                {
                //    List<MealTable> seedMeals = new List<MealTable>();
                //    seedMeals.Add(new MealTable("Cheese Sandwich", 45));
                //    seedMeals.Add(new MealTable("Omlet", 32));
                //    foreach (var meals in seedMeals)
                //{
                //    context.MealTables.Add(meals);
                //    context.SaveChanges();
                //}


                //var tieFoodToMeal = (from t in context.FoodMeals
                //                     join f in context.Foods      on t.FoodId equals f.FoodId
                //                     join m in context.MealTables on t.MealId equals m.MealId
                //                     select new );


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
