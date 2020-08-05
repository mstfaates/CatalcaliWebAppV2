using CatalcaliWebAppV2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalcaliWebAppV2.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
        public string ImageDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}