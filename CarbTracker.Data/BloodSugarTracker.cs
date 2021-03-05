using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Data
{
    public class BloodSugarTracker
    {
        [Key]
        public int BSLevelId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BSLevel { get; set; }
        [Required]
        public int CarbsConsumed { get; set; }
        public int InsulinToCarbRatio { get; set; }
        public int CorrectionFactor { get; set; }
        public int CurrentWeight { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
