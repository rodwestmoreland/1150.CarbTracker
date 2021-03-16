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
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "Too many characters in this in this field.")]
        public int BSLevel { get; set; }
        public int CarbsConsumed { get; set; }

        public Guid UserId { get; set; }
    }
}
