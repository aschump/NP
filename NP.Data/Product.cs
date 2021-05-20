using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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


        //[ForeignKey(nameof(SpecialDetail))]
        //public int? SpecialDetailID { get; set; }
        //public SpecialDetail SpecialDetail { get; set; }
        public int SpecialDetailID { get; set; }
        [ForeignKey("SpecialDetailID")]
        public virtual SpecialDetail SpecialDetail { get; set; }
        [Required]
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}