using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelApp.DAL.Data;

public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<HotelDbContext>()
            .UseSqlServer("Server=.;Database=HotelDb;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;
        return new HotelDbContext(options);
    }
}