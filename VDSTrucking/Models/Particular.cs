using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Particular
    {
        public int ParticularID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

        [Required]
        public int ParticularItemID { get; set; }
        public ParticularItem ParticularItem { get; set; }
    }
}
