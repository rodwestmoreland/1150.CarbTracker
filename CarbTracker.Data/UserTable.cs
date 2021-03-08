﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.Data
{
    public class UserTable
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public double InsulinToCarbRatio { get; set; }
        [Required]
        public double CorrectionFactor { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

    }
}
