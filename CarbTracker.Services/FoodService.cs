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
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Foods
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
    }
}
