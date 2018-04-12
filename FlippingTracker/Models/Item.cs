using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlippingTracker.Models
{
    public class Item
    {
        public string icon { get; set; }
        public string icon_large { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string typeIcon { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Current current { get; set; }
        public Today today { get; set; }
        public string members { get; set; }
    }
}
