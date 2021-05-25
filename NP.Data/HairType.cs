using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Data
{
    public class HairType
    {
        [Key]
        public int HairTypeID { get; set; }
        [Required]
        [Display(Name ="Type 1")]
        public bool TypeOne { get; set; }
        [Required]
        [Display(Name = "Type 2")]
        public bool TypeTwo { get; set; }
        [Required]
        [Display(Name = "Type 3")]
        public bool TypeThree { get; set; }
        [Required]
        [Display(Name = "Type 4")]
        public bool TypeFour { get; set; }
    }
}
