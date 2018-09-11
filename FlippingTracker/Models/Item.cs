using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlippingTracker.Models
{
    public class Item
    {
        public int itemId { get; set; }
        public string icon { get; set; }
        public string icon_large { get; set; }   
        public string type { get; set; }
        public string typeIcon { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool members { get; set; }
        public string trend { get; set; }
        public string price { get; set; }
        public Current Current { get; set; }
        public Today Today { get; set; }
    }
}
