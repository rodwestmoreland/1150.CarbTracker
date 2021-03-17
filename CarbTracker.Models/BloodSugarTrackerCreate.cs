using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class BloodSugarTrackerCreate
    {
        [Required]
        public int BSLevel { get; set; }
        public int CarbsConsumed { get; set; }

        public Guid UserId { get; set; }
    }
}
