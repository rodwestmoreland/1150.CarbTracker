using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Data
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Carbs { get; set; }

        public Food()
        {

        }

        public Food(string name, int carbs)
        {
            Name = name;
            Carbs = carbs;
        }

        private void SeedFoodDB()
        {
            Food eggLarge = new Food("Large Egg", 1);
            Food banana = new Food("Banana", 23);
            Food cheeseShreddedCheddar = new Food("Shredded Cheddar Cheese", 1);
            Food toastWholeGrain = new Food("Slice of Whole Grain Toast", 18);
            Food milk8oz = new Food("8 oz Glass of Milk", 12);
            Food juiceApple8oz = new Food("8 oz Apple Juice", 28);
            Food sandwichSlicedTurkey = new Food("Sliced Turkey Sandwaich", 35);
            Food cheetosSmall = new Food("Small Bag of Cheetos", 13);
            Food canOfCherryCoke = new Food("Can of Cherry Coke", 42);
            Food canOfCocaCola = new Food("Can of Coca Cola", 65);
            Food snickersLarge = new Food("Large Snickers Bar", 33);
        }
    }
}
