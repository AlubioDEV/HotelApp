using HotelApp.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<HotelDbContext>(o => o.UseSqlServer(connectionString));
        return services;
    }
}
