using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monova.Entity;
using Monova.Web.Providers;

namespace Monova.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //added my dbContext class. Database associated
            services.AddDbContext<MVDContext>(
                options => options.UseNpgsql("Server=192.168.99.100; Port=5432;Database=postgres;User Id=postgres;Password=mysecretpassword")
            );

            //identity configration settings [my edit]
            services
                .AddDefaultIdentity<MVDUser>()
                .AddEntityFrameworkStores<MVDContext>();

            services.Configure<IdentityOptions>(options =>
               {
                   // Password settings.
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
                   options.Password.RequiredLength = 1;
                   options.Password.RequiredUniqueChars = 1;

                   // Lockout settings.
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(14);
                   options.Lockout.MaxFailedAccessAttempts = 5;
                   options.Lockout.AllowedForNewUsers = true;

                   // User settings.
                   options.User.AllowedUserNameCharacters =
                              "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                   options.User.RequireUniqueEmail = false;
               });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.Cookie.Name = "monova-auth"; //login olduktan sonra application cookie bölümündeki cookinin default ismi

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });









            // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Simple example with dependency injection for a data provider.
            services.AddSingleton<IWeatherProvider, WeatherProviderFake>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); //Authentication added application pipeline

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
