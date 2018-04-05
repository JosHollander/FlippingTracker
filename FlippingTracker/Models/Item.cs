using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlippingTracker.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
    }
}
