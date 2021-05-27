using NP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP.Models.Lists
{
    public class HairTypeBuildList
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool TypeOne { get; set; }
        public bool TypeTwo { get; set; }
        public bool TypeThree { get; set; }
        public bool TypeFour { get; set; }
    }
}
