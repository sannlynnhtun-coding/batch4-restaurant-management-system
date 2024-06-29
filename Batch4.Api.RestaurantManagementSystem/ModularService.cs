using Batch4.Api.RestaurantManagementSystem.BL.Services.Category;
using Batch4.Api.RestaurantManagementSystem.DA;
using Batch4.Api.RestaurantManagementSystem.DA.Db;
using Batch4.Api.RestaurantManagementSystem.DA.Services.Category;

namespace Batch4.Api.RestaurantManagementSystem
{
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
            return services;
        }

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<BL_Category>();
            return services;
        }

    }
}
