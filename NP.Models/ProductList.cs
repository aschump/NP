using NP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Models
{
    //will collect all property data for a list of products
    public class ProductList
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Added on ")]
        public DateTimeOffset DateAdded { get; set; }
    }
}
