using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using MVC_ViewModels_Data.Models;
using Microsoft.EntityFrameworkCore;
using MVC_ViewModels_Data.Data;
using Microsoft.AspNetCore.Identity;

namespace MVC_ViewModels_Data
{
    public class Startup
    {
       //  private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        //in this method we canconfigure services for the project
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddControllersWithViews();

            services.AddDistributedMemoryCache();

            services.AddScoped<IPeopleRepo, DatabasePeopleRepo>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddDbContext<ExDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ExDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();


            services.AddSession(options =>
            {
                options.Cookie.Name = ".PriyaSession.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(300);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "people",
                    pattern: "People",
                    defaults: new { Controller = "People", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");
                endpoints.MapRazorPages();
            });
        }
    }
}
