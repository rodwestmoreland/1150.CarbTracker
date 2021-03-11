using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class MealTableListItem
    {
        public string Id { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public int? TotalCarbs { get; set; } 
    }
}
