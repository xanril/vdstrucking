using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Route
    {
        public int RouteID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Driver Rate")]
        public decimal DriverRate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name ="Helper Rate")]
        public decimal HelperRate { get; set; }

        [Required]
        public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}
