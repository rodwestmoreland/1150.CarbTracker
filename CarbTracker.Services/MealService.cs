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
        public IEnumerable<MealTableListItem> GetMeal()
        {

            using (var context = new ApplicationDbContext())
            {
                var query = context.MealTables
                                .Select(e => new MealTableListItem
                                {
                                    MealId = e.MealId,
                                    MealName = e.MealName,
                                    TotalCarbs = e.TotalCarbs
                                }
                            );

                return query.ToArray();
            }
        }

        public bool CreateMeal(MealTableCreate model)
        {
            var entity = new MealTable()
            {
                MealName = model.MealName
            };
            using (var context = new ApplicationDbContext())
            {
                context.MealTables.Add(entity);
                return context.SaveChanges() == 1;
            }
        }
    }
}
