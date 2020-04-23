using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using DeepakGallery.Data;
using DeepakGallery.Data.Entities;
using DeepakGallery.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DeepakGallery
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<GalleryUser, IdentityRole>(conf =>
            {
                conf.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<GalleryContext>();

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(conf =>
                {
                    conf.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = this.config["Tokens:Issurer"],
                        ValidAudience = this.config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.config["Tokens:Key"]))
                    };
                });

            services.AddDbContext<GalleryContext>(conf =>
            conf.UseSqlServer(config.GetConnectionString("GalleryConnectionString")));


            services.AddTransient<GalleryDataSeeder>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IMailService, NullMailSendService>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
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
            }

            app.UseStaticFiles();
            app.UseNodeModules();
            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(conf => conf.MapControllerRoute(
                "Fallback",
                "{controller}/{action}/{id?}",
                new { controller = "App", action = "Index" })
            );
        }
    }
}
