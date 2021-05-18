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
        public bool IsSulfateFree { get; set; }
        [Required]
        public bool IsParabenFree { get; set; }
        [Required]
        public bool IsFormaldehydeFree { get; set; }
        [Required]
        public bool IsAlcoholFree { get; set; }
        [Required]
        public bool IsAnimalTested { get; set; }
    }
}
