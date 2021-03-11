using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Data
{
    public class MealTable
    {
        public MealTable() { }
        public MealTable(string name, int carbs)
        {
            MealName =      name;
            TotalCarbs =    carbs;
        }

        [Key]
        public int      MealId { get; set; }
        
        [ForeignKey(nameof(ApplicationUser))]
        public string     Id { get; set; }
        
        [Required]
        public string   MealName { get; set; }
        public int?     TotalCarbs { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
