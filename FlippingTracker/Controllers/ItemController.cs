using FlippingTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FlippingTracker.Controllers
{
    public class ItemController : Controller
    {
        private IItemRepository repository;
        public int PageSize = 4;
        public ItemController(IItemRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ViewResult List(int productPage = 1) 
            => View(repository.Items
                .OrderBy(i => i.ItemID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize));
    }
}