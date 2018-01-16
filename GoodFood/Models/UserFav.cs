using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodFood.Models
{
    public class UserFav
    {
        public int id { get; set; }
        public int RecipeId { get; set; }
        public string userId { get; set; }

        public Recipe Recipe { get; set; }
        public ApplicationUser User { get; set; }
    }
}