using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using E_Shop.Models;

namespace E_Shop.Models
{
    [Bind(Exclude ="CategoryId")]
    public class Category
    {
        [Display(AutoGenerateField = true, Name = "Category Id")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name ="Category Description")]
        public string CategoryDescription { get; set; }

        public List<Product> Products { get; set; }
    }
}