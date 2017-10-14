using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class TripHelper
    {
        public int TripHelperID { get; set; }

        [Required]
        public int TripID { get; set; }
        public virtual Trip Trip { get; set; }

        [Required]
        public int HelperID { get; set; }
        public virtual Helper Helper { get; set; }
    }
}
