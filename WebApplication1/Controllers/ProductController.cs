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

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var objProductfromDb = _db.Products.Find(id);
/*            var objProductDbFirst = _db.Products.FirstOrDefault(u => u.Id == id);
            var objProductDbSingle = _db.Products.SingleOrDefault(u => u.Id == id);*/
            
            if(objProductfromDb == null)
            {
                return NotFound();
            }
            return View(objProductfromDb);
        }

        //POST
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            //Editing the database
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objProductfromDb = _db.Products.Find(id);
            /*            var objProductDbFirst = _db.Products.FirstOrDefault(u => u.Id == id);
                        var objProductDbSingle = _db.Products.SingleOrDefault(u => u.Id == id);*/

            if (objProductfromDb == null)
            {
                return NotFound();
            }
            return View(objProductfromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var objProductfromDb = _db.Products.Find(id);

            if (objProductfromDb == null)
            {
                return NotFound();
            }
            //Deleting from the database
            _db.Products.Remove(objProductfromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
