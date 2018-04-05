using System.Linq;

namespace FlippingTracker.Models
{
    //Get data through EF Core

    public class EFItemRepository : IItemRepository
    {
        private ApplicationDbContext context;

        public EFItemRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Item> Items => context.Items;
    }
}
