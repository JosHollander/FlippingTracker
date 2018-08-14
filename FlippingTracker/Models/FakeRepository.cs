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
            new Item { name = "Wand of the Cywir Elders", type = "Nex"},
            new Item { name = "Bandos tassets", type = "GWD"},
            new Item { name = "Bandos chestplate", type = "GWD"},
        }.AsQueryable<Item>();
    }
}
