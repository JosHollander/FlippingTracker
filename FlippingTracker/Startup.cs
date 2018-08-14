using FlippingTracker.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlippingTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>       
            Configuration = configuration;
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:FlippingTrackerItems:ConnectionString"]));
            services.AddTransient<IItemRepository, EFItemRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "pagination",
                    template: "Items/Page{itemPage}",
                    defaults: new {Controller = "Item", action = "List"});

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Item}/{action=List}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
