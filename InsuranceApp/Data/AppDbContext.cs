using Microsoft.EntityFrameworkCore;
using InsuranceApp.Models;

namespace InsuranceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
    }
}