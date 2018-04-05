using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FlippingTracker.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Items.Any())
            {
                context.Items.AddRange(
                    new Item { Name = "Wand of the Cywir Elders", Type = "Nex", Price = 11500000},
                    new Item { Name = "Bandos tassets", Type = "GWD", Price = 3200000},
                    new Item { Name = "Bandos chestplate", Type = "GWD", Price = 1600000},
                    new Item { Name = "Orb of the Cywir Elders", Type = "Nex", Price = 7000000 },
                    new Item { Name = "Sysmic wand", Type = "Nex", Price = 105100000 },
                    new Item { Name = "Noxious staff", Type = "Nex", Price = 159400000 }
                );
                context.SaveChanges();
            }
        }
    }
}
