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
                    new Item { name = "Wand of the Cywir Elders", type = "Nex", price = "15.1m" },
                    new Item { name = "Bandos tassets", type = "GWD", price = "3.2m"},
                    new Item { name = "Bandos chestplate", type = "GWD", price = "2.3m"},
                    new Item { name = "Orb of the Cywir Elders", type = "Nex", price = "7m" },
                    new Item { name = "Sysmic wand", type = "Nex", price = "1000m" },
                    new Item { name = "Noxious staff", type = "Nex", price = "146.1m" }
                );
                context.SaveChanges();
            }
        }
    }
}
