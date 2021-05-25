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
        public bool TypeOne { get; set; }
        [Required]
        public bool TypeTwo { get; set; }
        [Required]
        public bool TypeThree { get; set; }
        [Required]
        public bool TypeFour { get; set; }
    }
}
