using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("MemberPremiums")]
    public class MemberPremium
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(7)]
        public string DateOfBirth { get; set; } // mm/YYYY

        [Required]
        public int AgeNextBirthday { get; set; }

        [Required, MaxLength(50)]
        public string Occupation { get; set; }

        [Required, MaxLength(50)]
        public string OccupationRating { get; set; }

        [Required]
        public decimal OccupationFactor { get; set; }

        [Required]
        public decimal DeathCoverAmount { get; set; }

        [Required]
        public decimal MonthlyPremium { get; set; }

        [Required]
        public DateTime CalculatedOn { get; set; }
    }
}