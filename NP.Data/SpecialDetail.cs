using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Data
{
    public class SpecialDetail
    {
        [Key]
        public int SpecialDetailID { get; set; }
        [Required]
        [Display(Name = "Sulfate-Free")]

        public bool IsSulfateFree { get; set; }
        [Required]
        [Display(Name = "Paraben-Free")]

        public bool IsParabenFree { get; set; }
        [Required]
        [Display(Name = "Formaldehyde-Free")]

        public bool IsFormaldehydeFree { get; set; }
        [Required]
        [Display(Name = "Alcohol-Free")]

        public bool IsAlcoholFree { get; set; }
        [Required]
        [Display(Name = "Animal Tested?")]

        public bool IsAnimalTested { get; set; }
    }
}
