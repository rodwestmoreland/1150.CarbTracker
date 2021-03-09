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
        [Key]
        public int MealId { get; set; }
        
        public Guid UserId { get; set; }
        
        [Required]
        public string MealName { get; set; }
        public int? TotalCarbs { get; set; }
       

    }
}
