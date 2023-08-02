using mexxar.Data;
using mexxar.Models;
using Microsoft.AspNetCore.Mvc;

namespace mexxar.Controllers
{
    public class CategoryController : Controller
    {

        private readonly MexxarDbContext _db;
      

        public CategoryController(MexxarDbContext db)
        {
            _db = db;

        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.categories.ToList();
            return View(objCategoryList);
        }

        //Get
        
        public IActionResult Create()
        {

            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get

        public IActionResult Edit(int? id)
        {

            if (id==null || id==0) 
            {
                return NotFound();
            }
           var categoryFromDb = _db.categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //Get

        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTodo(int? id)
        {

            var obj = _db.categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            _db.categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
           
        }





    }
}
