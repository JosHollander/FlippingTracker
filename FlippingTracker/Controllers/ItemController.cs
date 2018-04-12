using FlippingTracker.Models;
using FlippingTracker.Models.ViewModels;
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
        public ViewResult List(int itemPage = 1)
            => View(new ItemsListViewModel
            {
                Items = repository.Items
                    .OrderBy(p => p.id)
                    .Skip((itemPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = itemPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Items.Count()
                }
            });
    }
}