using NP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Models
{
    public class CategoryBuildList
    {
        public int ProductID { get; set; } //Make this hidden when in List view
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool IsSulfateFree { get; set; }
        public bool IsParabenFree { get; set; }
        public bool IsFormaldehydeFree { get; set; }
        public bool IsAlcoholFree { get; set; }
        public bool IsAnimalTested { get; set; }
    }
}
