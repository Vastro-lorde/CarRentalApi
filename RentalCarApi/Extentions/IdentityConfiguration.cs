using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.Models;

namespace RentalCarApi.Extentions
{
    public static class IdentityConfiguration
    {
        public static void RegisterIdentityUser(this IServiceCollection services, IConfiguration cofig)
        {
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
