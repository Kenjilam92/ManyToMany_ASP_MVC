using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using products_categories.Models;

namespace products_categories.Controllers
{
    public class HomeController : Controller
    {   
        private static Context databases {get;set;}
        public HomeController(Context context)
        {
            databases = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return Redirect("/products");
        }
        [Route("products")]
        public IActionResult Product()
        {   
            ViewBag.Products = databases.Products.ToList();
            return View();
        }
        // [HttpPost]

    }
}
