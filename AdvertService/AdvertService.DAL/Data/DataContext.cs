using AdvertService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdvertService.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Advert> adverts { get; set; }
        public DbSet<AdvertToRequests> advertsToRequests { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AdvertToRequests>()
                .HasKey(e => new { e.advertId, e.requestId });

            builder
                .Entity<AdvertToRequests>()
                .HasOne(a => a.advert)
                .WithMany(r => r.advertToRequest)
                .HasForeignKey(a => a.advertId);
                
            builder.Entity<Advert>()
                .HasData(
                    new Advert
                    {
                        Id = 1,
                        name = "TestAdvert",
                        description = "TestDesacription",
                        cost = 500,
                        location = "Kyiv",
                        startTime = new DateTime(2020, 9, 9),
                        endTime = new DateTime(2021, 10, 10)
                    }
                );
            
            base.OnModelCreating(builder);
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../AdvertService/appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<DataContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new DataContext(builder.Options);
            }
        }
    }
}
