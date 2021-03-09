using CarbTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Models
{
    public class MealTableCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "Too many characters in this in this field.")]
        public string MealName { get; set; }
        public int TotalCarbs { get; set; }
        [ForeignKey(nameof(UserTable))]
        public Guid UserId { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
