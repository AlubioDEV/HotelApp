using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddBl(this IServiceCollection services)
    {
        // Aquí se registrarán los servicios de cada módulo
        return services;
    }
}
