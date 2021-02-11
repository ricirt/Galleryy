using GalleryBusiness.Core;
using GalleryBusiness.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using FluentValidation.AspNetCore;
using Gallery.ViewModels;
using FluentValidation;
using Gallery.Validators;

namespace GalleryFront
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
            services.AddSession();
            services.AddMemoryCache();
            // services.AddDistributedMemoryCache(); 


            services.AddControllersWithViews().AddFluentValidation();
            services.AddTransient<IValidator<ProfilViewModel>, ProfilViewModelValidator>();


            services.AddScoped<IArtist, CArtist>();
            services.AddScoped<IArtWork, CArtWork>();
            services.AddScoped<IUserLogin, CUserLogin>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Path = "/";
                    options.Cookie.Name = "GalleryCookie";
                    options.Cookie.Domain = Configuration["localhost"];
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = c => OnRedirectToLogin(c, Configuration),
                    };

                    //options.LoginPath = "/Home/Login";

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
        private static Task OnRedirectToLogin(RedirectContext<CookieAuthenticationOptions> context, IConfiguration configuration)
        {
            context.HttpContext.Response.Redirect(configuration + "Login/Login");
            return Task.CompletedTask;
        }
    }
}
