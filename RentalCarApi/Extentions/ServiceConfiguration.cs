using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using RentalCarCore.Implementations;
using RentalCarCore.Interfaces;
using RentalCarCore.Services;
using RentalCarInfrastructure.Repositories.Implementations;
using RentalCarInfrastructure.Repositories.Interfaces;

namespace RentalCarApi.Extentions
{
    public static class ServiceConfiguration
    {
        public static void ConfigurationService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenGen, TokenGen>();
        }
    }
}
