using Microsoft.EntityFrameworkCore;
using UserService.DAL.Entities;

namespace UserService.DAL.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}