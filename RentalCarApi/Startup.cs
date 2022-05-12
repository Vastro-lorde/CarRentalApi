using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RentalCarApi.Extentions;
<<<<<<< HEAD
using RentalCarCore.Interfaces;
using RentalCarCore.Services;
using RentalCarCore.Utilities;
=======
using RentalCarApi.Middlewares;
>>>>>>> reviews
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
<<<<<<< HEAD
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IImageService, ImageService>();
            services.Configure<ImageUploadSettings>(Configuration.GetSection("ImageUploadSettings"));
            services.ConfigurationService();
=======
<<<<<<< HEAD
>>>>>>> 9f7bd7411c370e2fcee6076d7a19d140eebbbb92
            services.AddSwaggerConfiguration();
            services.AddCorsConfiguration();
            services.AddControllers();
            services.RegisterDbContext(Configuration);
            services.RegisterIdentityUser(Configuration);
            services.ConfigureAuthentication(Configuration);
=======

            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddSwaggerConfiguration();
            services.AddControllers();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.Configure<ImageUploadSettings>(Configuration.GetSection("ImageUploadSettings"));
            services.ConfigureAuthentication(Configuration);

<<<<<<< HEAD
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContextAndConfigurations(Environment, Configuration);
            services.RegisterIdentityUser(Configuration);
=======


            services.AddAutoMapper(typeof(Startup));
            services.AddDbContextAndConfigurations(Environment, Configuration);
            services.RegisterIdentityUser(Configuration);
            services.ConfigureCors();

>>>>>>> reviews
>>>>>>> 9f7bd7411c370e2fcee6076d7a19d140eebbbb92
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager, AppDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Rental Api v1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthorization();
            Seeder.Seed(roleManager, userManager, dbContext).GetAwaiter().GetResult();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}