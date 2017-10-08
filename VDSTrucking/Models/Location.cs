using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [Required]
        [MaxLength(75), MinLength(2)]
        public string Name { get; set; }
    }
}
