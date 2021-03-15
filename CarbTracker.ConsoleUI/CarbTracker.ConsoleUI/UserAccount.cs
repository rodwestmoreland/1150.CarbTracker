﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarbTracker.ConsoleUI
{
    public class UserAccount
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double InsulinToCarbRatio { get; set; }
        public double CorrectionFactor { get; set; }
        
    }
}
