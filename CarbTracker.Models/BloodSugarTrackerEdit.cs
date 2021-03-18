using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class BloodSugarTrackerEdit
    {
        public Guid Id { get; set; }
        public int BSLevelId { get; set; }
        public int BSLevel { get; set; }
        public int CarbsConsumed { get; set; }
    }
    public class SettingsEdit
    {
        public double InsulinToCarbRatio { get; set; }
        public double CorrectionFactor { get; set; }
    }
}
