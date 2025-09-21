using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;

namespace PointSales.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserBLL, UserBLL>();
            services.AddScoped<IUserDAL, UserDAL>();

            services.AddScoped<ICategoryBLL, CategoryBLL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();

            services.AddScoped<ICustomerBLL, CustomerBLL>();
            services.AddScoped<ICustomerDAL, CustomerDAL>();

            services.AddScoped<IProductBLL, ProductBLL>();
            services.AddScoped<IProductDAL, ProductDAL>();

            services.AddScoped<IBuyBLL, BuyBLL>();
            services.AddScoped<IBuyDAL, BuyDAL>();

            services.AddScoped<IBuyProductBLL, BuyProductBLL>();
            services.AddScoped<IBuyProductDAL, BuyProductDAL>();

            return services;
        }

    }
}