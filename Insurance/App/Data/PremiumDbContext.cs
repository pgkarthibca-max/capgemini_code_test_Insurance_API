using App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace App.Data
{
    public class PremiumDbContext : DbContext
    {
        public PremiumDbContext() : base("name=PremiumDbContext")
        {
        }

        public DbSet<MemberPremium> MemberPremiums { get; set; }

       
    }
}