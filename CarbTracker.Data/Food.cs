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
        public string FoodName { get; set; }
        public int Carbs { get; set; }
    }
}
