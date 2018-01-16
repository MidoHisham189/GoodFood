using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoodFood.Models;
namespace GoodFood.ViewModel
{
    public class RecipeViewModel
    {
        public Recipe recipe { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public HttpPostedFileBase File { get; set; }

    }
}