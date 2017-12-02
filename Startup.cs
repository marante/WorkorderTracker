using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BravisWorkplanner.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BravisWorkplanner
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
            
            services.AddDbContext<BravisDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("BravisDbContext")));
                              
            services.AddMvc()
            .AddRazorOptions(options => 
            {
                options.PageViewLocationFormats.Add("/Pages/Shared/{0}.cshtml");
            })
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Shared/Error", "Error");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
