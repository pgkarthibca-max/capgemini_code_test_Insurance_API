using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App.Models
{
    public class PremiumRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 150)]
        public int AgeNextBirthday { get; set; }

        [Required]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "DOB must be in mm/YYYY format")]
        public string DateOfBirth { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal DeathCoverAmount { get; set; }
    }
    
}