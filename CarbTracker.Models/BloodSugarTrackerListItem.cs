using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class BloodSugarTrackerListItem
    {
        public string Id { get; set; }
        public int BSLevelId { get; set; }
        public int BSLevel { get; set; }
        public int CarbsConsumed { get; set; }
    }
}
