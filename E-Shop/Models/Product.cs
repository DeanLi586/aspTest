using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using E_Shop.Models;
using System.Web.Mvc;

namespace E_Shop.Models
{
    [Bind(Exclude ="ProductId")]
    public class Product
    {
        [Display(AutoGenerateField =true)]
        public int ProductId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, 1000, ErrorMessage ="Price Must Be Between 0.01 & 1000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Image")]
        public string Image { get; set; }

        [Required]
        public virtual Category Category { get; set; }
    }
}