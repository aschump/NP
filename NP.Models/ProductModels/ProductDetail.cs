using NP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Models
{
    public class ProductDetail
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public bool TypeOne { get; set; }
        public bool TypeTwo { get; set; }
        public bool TypeThree { get; set; }
        public bool TypeFour { get; set; }
        public bool IsSulfateFree { get; set; }
        public bool IsParabenFree { get; set; }
        public bool IsFormaldehydeFree { get; set; }
        public bool IsAlcoholFree { get; set; }
        public bool IsAnimalTested { get; set; }
        public int PlanID { get; set; }
        [Display(Name = "Added")]
        public DateTimeOffset DateAdded { get; set; }
        [Display(Name = "Updated")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
