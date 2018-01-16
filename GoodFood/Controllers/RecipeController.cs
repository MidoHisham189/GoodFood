using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoodFood.ViewModel;
using GoodFood.Models;
using System.Data.Entity;
using System.IO;
namespace GoodFood.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext db;

        public RecipeController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Recipe
        public ActionResult Index()
        {
            
            return View(db.Recipes.Include(r=> r.Category).ToList());
        }

        public ActionResult AddNew()
        {

            var viewModel = new RecipeViewModel
            {

                recipe = new Recipe(),
                Categories = db.Category.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddNew(Recipe recipe , HttpPostedFileBase File)
        {
            if (recipe.id == 0)
            {
                db.Recipes.Add(recipe);

            }
            else
            {

                var recipeInDb = db.Recipes.SingleOrDefault(r => r.id == recipe.id);

                recipeInDb.RecipeName = recipe.RecipeName;
                recipeInDb.RecipeDiscription = recipe.RecipeDiscription;
                recipeInDb.CategoryId = recipe.CategoryId;

                if (File != null && File.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Iamges") + "/" +recipe.CategoryId+recipe.id + ".jpg");
                    File.SaveAs(path);


                }
            }
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
          var recipe =  db.Recipes.SingleOrDefault(r => r.id == id);

            var viewmodel = new RecipeViewModel
            {
                recipe = recipe,
                Categories = db.Category.ToList()
                
            };
            return View("AddNew", viewmodel);
        }
    }
}