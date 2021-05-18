using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Data
{
    public enum Category
    {
        Shampoo,
        Conditioner,
        DeepConditioner,
        LeaveInConditioner,
        Moisturizer,
        HairColor,
        StylingTool,
        Oil
    }
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Category Category { get; set; }
        public bool IsSulfateFree { get; set; }
        public bool IsParabenFree { get; set; }
        public bool IsFormaldehydeFree { get; set; }
        public bool IsAlcoholFree { get; set; }
        public bool IsAnimalTested { get; set; }

        [Required]
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}