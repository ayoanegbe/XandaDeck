using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XandaDeck.Core.Services;
using XandaDeck.Data.Constants;
using XandaDeck.Data.Contexts;
using XandaDeck.Data.Models;

namespace XandaDeck.Web
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages().WithRazorPagesRoot("/Home");

            services.Configure<RecaptchaSettings>(Configuration.GetSection("GoogleRecaptchaV3"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<INumberSequence, NumberSequence>();
            services.AddSingleton<UniqueCode>();
            services.AddSingleton<CustomIDataProtection>();
            services.AddSingleton<RecaptchaService>();

            services.AddHttpClient();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = ".Xandadeck";
                options.Cookie.Path = "/";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.Name = Constants.VisitorRef;
                options.Cookie.IsEssential = true;
                options.Cookie.Expiration = TimeSpan.FromDays(365);
            });

            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                //options.FormFieldName = "AntiforgeryFieldname";
                options.HeaderName = "XSRF-TOKEN";
                options.SuppressXFrameOptionsHeader = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddFile($"{env.WebRootPath}\\Logs\\Log.json");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestHeaderMiddleware();

            app.UseSession();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                //context.Response.Headers.Add("Strict-Transport-Security", "max-age=86400");
                context.Response.Headers.Add("Cache-Control", "no-cache");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
                context.Response.Headers.Remove("X-Powered-By");

                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}");
            });

            
        }
    }
}
