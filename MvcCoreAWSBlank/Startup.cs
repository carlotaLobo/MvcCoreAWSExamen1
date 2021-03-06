using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcCoreAWSBlank.Data;

using MvcCoreAWSBlank.Services;

namespace MvcCoreAWSBlank
{
    public class Startup
    {
        IConfiguration configure;

        public Startup(IConfiguration configuration)
        {
            this.configure = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = this.configure.GetConnectionString("awsmariadb");
            services.AddAWSService<IAmazonS3>();
            services.AddTransient<PersonajesServiceDynamodb>();
            services.AddTransient<PersonajesServiceS3>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
