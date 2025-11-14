using Microsoft.EntityFrameworkCore;
using Insurance.Domain.Entities;


namespace Insurance.Application.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Occupation> Occupations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Occupation>().ToTable("occupations");
        modelBuilder.Entity<Member>().ToTable("members");


            // optional: seed occupations
            modelBuilder.Entity<Occupation>().HasData(
            new Occupation { Id = 1, OccupationName = "Cleaner", Rating = "Light Manual", RatingFactor = 1.50m },
            new Occupation { Id = 2, OccupationName = "Doctor", Rating = "Professional", RatingFactor = 1.50m },
            new Occupation { Id = 3, OccupationName = "Author", Rating = "White Collar", RatingFactor = 2.25m },
            new Occupation { Id = 4, OccupationName = "Farmer", Rating = "Heavy Manual", RatingFactor = 3.75m },
            new Occupation { Id = 5, OccupationName = "Mechanic", Rating = "Heavy Manual", RatingFactor = 3.75m },
            new Occupation { Id = 6, OccupationName = "Florist", Rating = "Light Manual", RatingFactor = 1.50m },
            new Occupation { Id = 7, OccupationName = "Other", Rating = "Heavy Manual", RatingFactor = 3.75m }
            );
        }
    }
}