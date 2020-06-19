using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Products()
        {   
            ViewBag.Products = databases.Products.ToList();
            return View();
        }
        [Route("categories")]
        public IActionResult Categories()
        {   
            ViewBag.Categories = databases.Categories.ToList();
            return View();
        }
        [Route("/product/{id}")]
        public IActionResult ProductDetails (int id)
        {   
            ViewBag.ChoosenOne = databases.Products
                .Include(p => p.AllCategories)
                .ThenInclude(a => a.CategoryDetails)
                .FirstOrDefault(p => p.ProductId == id);
            // List<Category> AllReady = new List<Category>{};
            // foreach( var c in ViewBag.ChoosenOne.AllCategories)
            //     {
            //         AllReady.Add(c.CategoryDetails);
            //     }
            // ViewBag.Categories = databases.Categories.Where(c => !AllReady.Contains(c)).ToList();

            ViewBag.Categories= databases.Categories
                .ToList()
                .Except(databases.Products
                    .Include(p =>p.AllCategories)
                    .ThenInclude(pc => pc.CategoryDetails)
                    .FirstOrDefault(p => p.ProductId == id)
                    .AllCategories.Select(a => a.CategoryDetails))
                .ToList();
            return View();
        }
        [Route("/category/{id}")]
        public IActionResult CategoryDetails (int id)
        {   
            ViewBag.ChoosenOne = databases.Categories
                .Include(c => c.AllProducts)
                .ThenInclude(a => a.ProductDetails)
                .FirstOrDefault(p => p.CategoryId == id);
            
            ViewBag.Products= databases.Products
                .ToList()
                .Except(databases.Categories
                    .Include(p =>p.AllProducts)
                    .ThenInclude(pc => pc.ProductDetails)
                    .FirstOrDefault(p => p.CategoryId == id)
                    .AllProducts.Select(a => a.ProductDetails))
                .ToList();
            return View();
        }

        [HttpPost]
        [Route("products/create")]
        public IActionResult CreateProduct(Product newproduct)
        {
            if (ModelState.IsValid)
            {   
                databases.Products.Add(newproduct);
                databases.SaveChanges();
                return Redirect("/products");
            }
            ViewBag.Products = databases.Products.ToList();
            return View("Products");
        }
        [Route("product/{id}/add")]
        public IActionResult AddCategory(int id, Association Associate)    
        {
            if(ModelState.IsValid)
            {
                databases.Associations.Add(Associate);
                databases.SaveChanges();
                return Redirect($"/product/{id}");
            }
            return View("ProductDetails");
        }

        [Route("Categories/create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {   
                databases.Categories.Add(newCategory);
                databases.SaveChanges();
                return Redirect("/categories");
            }
            ViewBag.Categories = databases.Categories.ToList();
            return View("Categories");
        }
    }
}
