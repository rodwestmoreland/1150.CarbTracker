using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Data
{
    public class FoodMeal
    {
        [Key]
        public int FoodMealId { get; set; }
        
        [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }
        
        [ForeignKey(nameof(MealTable))]
        public int MealId { get; set; }

        public virtual Food Food { get; set; }
        public virtual MealTable MealTable { get; set; }

        public FoodMeal() { }
        public FoodMeal(int foodId, int mealId )
        {
            FoodId = foodId;
            MealId = mealId;
        }

    }
}
