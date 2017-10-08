using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class ParticularItem
    {
        public int ParticularItemID { get; set; }

        [MaxLength(50), MinLength(2), Required]
        public string Name { get; set; }
    }
}
