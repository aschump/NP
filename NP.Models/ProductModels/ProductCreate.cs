using NP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Models
{
    public class ProductCreate
    {
        [Required]
        public string Name { get; set; }
        public string Ingredients { get; set; }
        [Required]
        public string Description { get; set; }
        public double Price { get; set; }
        [Required]
        public Category Category { get; set; }
        [Display(Name ="Type 1")]
        public bool TypeOne { get; set; }
        [Display(Name = "Type 2")]

        public bool TypeTwo { get; set; }
        [Display(Name = "Type 3")]

        public bool TypeThree { get; set; }
        [Display(Name = "Type 4")]

        public bool TypeFour { get; set; }
        [Display(Name = "Sulfate-Free")]
        public bool IsSulfateFree { get; set; }
        [Display(Name = "Paraben-Free")]

        public bool IsParabenFree { get; set; }
        [Display(Name = "Formaldehyde-Free")]

        public bool IsFormaldehydeFree { get; set; }
        [Display(Name = "Alcohol-Free")]

        public bool IsAlcoholFree { get; set; }
        [Display(Name = "Animal Tested")]

        public bool IsAnimalTested { get; set; }
        [Display(Name = "Hair Plan 1-3")]

        public int PlanID { get; set; }
        public DateTimeOffset DateAdded { get; set; }
    }
}
