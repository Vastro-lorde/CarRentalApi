using Microsoft.Extensions.DependencyInjection;

namespace RentalCarApi.Extentions
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfiguration(this IServiceCollection services) =>
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
    }
}
