using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Particular
    {
        public int ParticularID { get; set; }
        public decimal Cost { get; set; }

        public int ParticularItemID { get; set; }
        public ParticularItem ParticularItem { get; set; }
    }
}
