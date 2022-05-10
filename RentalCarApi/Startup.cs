using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RentalCarApi.Extentions;
using RentalCarInfrastructure.Context;
using RentalCarInfrastructure.ModelImage;
using RentalCarInfrastructure.ModelMail;
using RentalCarInfrastructure.Models;
using RentalCarInfrastructure.Repositories.Implementations;
using RentalCarInfrastructure.Repositories.Interfaces;
using static RentalCarInfrastructure.Seeder.Seeders;

namespace RentalCarApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;  
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IImageService, ImageService>();
            services.Configure<ImageUploadSettings>(Configuration.GetSection("ImageUploadSettings"));

            services.AddSwaggerConfiguration();
            services.AddCorsConfiguration();
            services.ConfigureAuthentication(Configuration);

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContextAndConfigurations(Environment, Configuration);
            services.RegisterIdentityUser(Configuration);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
<<<<<<< HEAD
<<<<<<< HEAD
                
=======

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentalCarApi v1");
                });
>>>>>>> c624222c11d759848822ae60f3a5880087eb9e50
=======
>>>>>>> 8f0f94466e24035cd2bf27ba317d6fd61269edc2
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentalCarApi v1");
            });

<<<<<<< HEAD
            //app.UseHttpsRedirection();
=======
            app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RentalCarApi v1"));
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Rental Api v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
>>>>>>> c624222c11d759848822ae60f3a5880087eb9e50

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();
            Seeder.Seed(roleManager, userManager, dbContext).GetAwaiter().GetResult();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}