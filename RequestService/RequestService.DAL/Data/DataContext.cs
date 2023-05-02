using RequestService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using RequestService.DAL.Enums;

namespace RequestService.DAL.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Request>()
                .HasData(
                    new Request
                    {
                        Id = 1,
                        UserId = "eab08aff-4a7f-46e8-a1c2-a3f4ac951ef6",
                        AdvertId = 1,
                        Status = RequestStatusEnum.applied
                    }
                );
            
            base.OnModelCreating(builder);
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../RequestService/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new DataContext(builder.Options);
        }
    }
}
