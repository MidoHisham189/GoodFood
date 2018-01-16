using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoodFood.Models;
namespace GoodFood.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext db;
        // GET: Category
        public CategoryController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(db.Category.ToList());
        }

        public ActionResult AddNew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNew(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}