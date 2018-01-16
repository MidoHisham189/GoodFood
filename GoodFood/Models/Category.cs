using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace GoodFood.Models
{
    public class Category
    {
        public int id { get; set; }

        [Display( Name= "Category Name")]
        public string CategoryName { get; set; }

        public virtual  ICollection<Recipe> recipes { get; set; }
    }
}