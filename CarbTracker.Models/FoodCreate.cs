using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class FoodCreate
    {
        
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "Too many characters in this in this field.")]
        public string Name { get; set; }
        [Required]
        public int Carbs { get; set; }
        [Required]
        public double ServingInOunces { get; set; }
        public string Description { get; set; }
    }
}
