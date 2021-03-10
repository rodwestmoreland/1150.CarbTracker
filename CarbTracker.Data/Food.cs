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
        [Required]
        public int Carbs { get; set; }
        [Required]
        public double ServingInOunces { get; set; }
        public string Description { get; set; }

        public Food()
        {

        }

        public Food(string name, int carbs, double servingSizeOunces)
        {
            Name = name;
            Carbs = carbs;
            ServingInOunces = servingSizeOunces;

        }

        public Food(string name, int carbs, double servingSizeOunces, string description)
        {
            Name = name;
            Carbs = carbs;
            ServingInOunces = servingSizeOunces;
            Description = description;
        }

 


        public void SeedFoodDB()
        {
            Food eggLarge = new Food("Large Egg", 1, 2.25);
            Food banana = new Food("Banana", 23, 4.5);
            Food cheeseShreddedCheddar = new Food("Shredded Cheddar Cheese", 1, 4.0);
            Food toastWholeGrain = new Food("Slice of Whole Grain Toast", 18, 1.25);
            Food milk8oz = new Food("8 oz Glass of Milk", 12, 8.0);
            Food juiceApple8oz = new Food("8 oz Apple Juice", 28, 8.0);
            Food sandwichSlicedTurkey = new Food("Sliced Turkey Sandwich", 35, 5.0);
            Food cheetosSmall = new Food("Small Bag of Cheetos", 13, 8.5);
            Food canOfCherryCoke = new Food("Can of Cherry Coke", 42, 12.0);
            Food canOfCocaCola = new Food("Can of Coca Cola", 65, 12.0);
            Food snickersLarge = new Food("Large Snickers Bar", 28, 2.0);
        }
    }
}
