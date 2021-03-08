using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Data
{
    public class BloodSugarTracker
    {
        [Key]
        public int BSLevelId { get; set; }
        [ForeignKey(nameof(UserTable))]
        public Guid UserId { get; set; }
        [Required]
        public int BSLevel { get; set; }
        [Required]
        public int CarbsConsumed { get; set; }
        public int CurrentWeight { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
    
        public virtual UserTable UserTable { get; set; }
    }
    
}
