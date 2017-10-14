using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class HelperList
    {
        public int HelperListID { get; set; }

        [Required]
        [ForeignKey("Trip")]
        public int TripID { get; set; }
        public virtual Trip Trip { get; set; }

        [Required]
        public virtual ICollection<Helper> Helpers { get; set; }
    }
}
