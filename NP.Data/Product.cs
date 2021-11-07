using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Description("Deep Conditioner")]
        DeepConditioner,
        [Description("Leave-In Conditioner")]
        LeaveInConditioner,
        Moisturizer,
        [Description("Hair Color")]
        HairColor,
        [Description("Styling Tool")]
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
        
        [Required]
        public int HairTypeID { get; set; }
        [ForeignKey("HairTypeID")]
        public virtual HairType HairType { get; set; }
        public int SpecialDetailID { get; set; }
        [ForeignKey("SpecialDetailID")]
        public virtual SpecialDetail SpecialDetail { get; set; }
        public int PlanID { get; set; }
        [ForeignKey("PlanID")]
        public virtual Plan Plan { get; set; }

        [Required]
        public DateTimeOffset DateAdded { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}