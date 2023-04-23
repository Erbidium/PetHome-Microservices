using Microsoft.EntityFrameworkCore;
using UserService.DAL.Entities;

namespace UserService.DAL.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = Guid.Parse("eab08aff-4a7f-46e8-a1c2-a3f4ac951ef6"),
                    Email = "TestMail.com",
                    Name = "TestName",
                    Location = "TestLocation",
                    Password = "QWERTY123"
                }
            );
    }
}