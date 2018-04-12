using System.Collections.Generic;

namespace FlippingTracker.Models.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
