using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoodFood.Models;
namespace GoodFood.ViewModel
{
    public class ShowRecipeViewModel
    {
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Recipe> recipes { get; set; }
    }
}