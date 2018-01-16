using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GoodFood.Models;
using System.Data.Entity;
namespace GoodFood.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db;

        public UserController()
        {
            db = new ApplicationDbContext();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Favourite(string userId)
        {
            var fav = db.Favourites
                .Include(f => f.Recipe)
                .Where(f => f.userId == userId)
                .ToList();
                
            return View(fav);
        }

        
        public ActionResult DeleteFromFavourite(int favId)
        {
          var fav = db.Favourites.SingleOrDefault(x => x.id == favId);
          db.Favourites.Remove(fav);
          db.SaveChanges();

          return Json("Favourite Is Deleted");
        }
    }
}