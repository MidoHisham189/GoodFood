using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoodFood.Models;
namespace GoodFood.ViewModel
{
    public class HomePageViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<UserFav> Favourites { get; set; }
    }
}