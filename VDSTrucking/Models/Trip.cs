using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Trip
    {
        public int TripID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public int RouteID { get; set; }
        public virtual Route Route { get; set; }

        [Required]
        public int TruckID { get; set; }
        public virtual Truck Truck { get; set; }

        [Required]
        public int DriverID { get; set; }
        public virtual Driver Driver { get; set; }

        public int HelperListID { get; set; }
        public virtual HelperList HelperList { get; set; }

        public virtual ICollection<Particular> Particulars { get; set; }
    }
}
