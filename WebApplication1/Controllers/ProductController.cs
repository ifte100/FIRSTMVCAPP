using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {   
            IEnumerable<Product>objProductList = _db.Products;
            return View(objProductList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            //adding to the database
            if(ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
