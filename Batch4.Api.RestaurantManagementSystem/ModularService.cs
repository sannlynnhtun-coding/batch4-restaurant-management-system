namespace Batch4.Api.RestaurantManagementSystem;

public static class ModularService
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddDataAccessServices();
        services.AddBusinessLogicServices();
        return services;
    }

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        services.AddScoped<DA_Category>();
        services.AddScoped<DA_MenuItem>();
        services.AddScoped<DA_Order>();
        return services;
    }

    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<BL_Category>();
        services.AddScoped<BL_MenuItem>();
        services.AddScoped<BL_Order>();
        return services;
    }

}
