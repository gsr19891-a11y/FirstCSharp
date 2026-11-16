using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FitZone.Infrastructure.Data
{
    public class FitZoneDbContextFactory : IDesignTimeDbContextFactory<FitZoneDbContext>
    {
        public FitZoneDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FitZoneDbContext>();

            
            optionsBuilder.UseSqlServer("Server=ADMIN;Database=FitZoneAppDb;Trusted_Connection=True;TrustServerCertificate=True;");

            return new FitZoneDbContext(optionsBuilder.Options);
        }
    }
}