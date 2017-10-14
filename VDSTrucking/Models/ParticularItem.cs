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

        [Required]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; }
    }
}
