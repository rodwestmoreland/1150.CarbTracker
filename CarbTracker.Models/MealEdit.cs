using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class MealEdit
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public int TotalCarbs { get; set; }
        public Guid Id { get; set; }
    }
}
