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
        public Food() { }
        public Food(string name, int carbs, double servingSizeOunces)
        {
            Name =              name;
            Carbs =             carbs;
            ServingInOunces =   servingSizeOunces;
        }

        public Food(string name, int carbs, double servingSizeOunces, string description)
        {
            Name =              name;
            Carbs =             carbs;
            ServingInOunces =   servingSizeOunces;
            Description =       description;
        }

        [Key]
        public int      FoodId { get; set; }
        [Required]
        public string   Name { get; set; }

        public string   Description { get; set; }
        [Required]
        public int      Carbs { get; set; }
        [Required]
        public double   ServingInOunces { get; set; }
        

        
    }
}
