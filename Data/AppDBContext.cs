using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    private readonly string _configurationString = "Host=localhost;Port=5432;Database=test;Username=daniel;Password=1234;";

    public DbSet<User> Users { get; set; } // User table

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configurationString); // PostgreSQL connection
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserId)
            .IsUnique(); // user_id unique constraint

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique(); // email unique constraint

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Nickname)
            .IsUnique(); // nickname unique constraint
    }
}
