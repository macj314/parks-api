using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
    public class ParksApiContext : DbContext
    {
      public DbSet<Park> Parks { get; set; }
      public DbSet<User> Users { get; set; }

      public ParksApiContext(DbContextOptions<ParksApiContext> options)
          : base(options)
      {
      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Fort Casey", Type = "State", Description = "Marine camping ground", Rating = 3, UserId = 1 },
          new Park { ParkId = 2, Name = "Old Fort Townsend", Type = "State", Description = "Shoreline on Port Townsend Bay", Rating = 4, UserId = 1},
          new Park { ParkId = 3, Name = "Olympic", Type = "National", Description = "Snow covered mountains, lush rain forests & dramatic Pacific coastline", Rating = 5, UserId = 1 }
        );

        builder.Entity<User>()
        .HasData(
          new User { Id = 1, Username = "Test", Password = "test" }
        );
      }
    }
}
