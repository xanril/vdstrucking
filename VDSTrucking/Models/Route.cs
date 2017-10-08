using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Route
    {
        public int RouteID { get; set; }
        public decimal Rate { get; set; }
        public decimal DriverRate { get; set; }
        public decimal HelperRate { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}
