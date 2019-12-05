using CustomerHub.Application.Services;
using CustomerHub.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerHub.Application.Ioc
{
    public static class IocService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}