using Microsoft.EntityFrameworkCore;

public class AppDBContext : DbContext
{
    public DbSet<User> Users { get; set; } // User table

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {

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
