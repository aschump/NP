using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Models.ProductModels
{
    public class PlanEdit
    {
        [Range(1, 100)]
        public int PlanID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
