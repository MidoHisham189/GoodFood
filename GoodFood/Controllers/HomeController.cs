using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoodFood.ViewModel;
using GoodFood.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace GoodFood.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var Categories = db.Category
                .Include(c => c.recipes)
                .ToList();

            return View(Categories);

        }

       [Authorize]
        public ActionResult AddToFavourite(int recepId )
        {
           var userId = User.Identity.GetUserId();
           var favAdded = db.Favourites.Where(f => f.userId == userId && f.RecipeId == recepId).ToList();
           if (favAdded.Count != 0)
           {
               
               return Json(favAdded);
           }
           else
           {
               var fav = new UserFav
               {
                   RecipeId = recepId,
                   userId = userId
               };
               db.Favourites.Add(fav);
               db.SaveChanges();
           }


           return Json(favAdded);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult RecipeDetail(int? id)
        {
            var recipe = db.Recipes.SingleOrDefault(x => x.id == id);

            return View(recipe);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }


}