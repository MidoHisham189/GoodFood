using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFood.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public string RecipeName { get; set; }
        public string RecipeDiscription { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}