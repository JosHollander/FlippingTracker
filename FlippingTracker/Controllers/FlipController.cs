using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlippingTracker.Controllers
{
    public class FlipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}