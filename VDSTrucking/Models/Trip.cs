using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Trip
    {
        public int TripID { get; set; }
        public DateTime Date { get; set; }

        public int TruckID { get; set; }
        public Truck Truck { get; set; }

        public int DriverID { get; set; }
        public Driver Driver { get; set; }

        public ICollection<Helper> Helpers { get; set; }

        public ICollection<Particular> Particulars { get; set; }
    }
}
