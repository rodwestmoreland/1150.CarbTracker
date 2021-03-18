using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class BSType
    {
        public int BSLevel { get; set; }
        public int CarbsConsumed { get; set; }
    }
    public class SettingsType
    {
        public double InsulinToCarbRatio { get; set; }
        public double CorrectionFactor { get; set; }
    }
}
