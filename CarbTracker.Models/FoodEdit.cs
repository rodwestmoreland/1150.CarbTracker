using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class FoodEdit
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public int Carbs { get; set; }
        public double ServingInOunces { get; set; }
        public string Description { get; set; }
    }
}
