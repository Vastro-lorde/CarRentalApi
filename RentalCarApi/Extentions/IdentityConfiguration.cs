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
            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireUppercase = true;
                x.SignIn.RequireConfirmedEmail = true;
                x.Password.RequiredLength = 5;
                x.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
