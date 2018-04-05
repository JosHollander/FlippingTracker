using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlippingTracker.Models
{
    public class FakeRepository : IItemRepository
    {
        public IQueryable<Item> Items => new List<Item>
        {
            new Item { Name = "Wand of the Cywir Elders", Type = "Nex"},
            new Item { Name = "Bandos tassets", Type = "GWD"},
            new Item { Name = "Bandos chestplate", Type = "GWD"},
        }.AsQueryable<Item>();
    }
}
