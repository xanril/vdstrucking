using System;
using System.ComponentModel.DataAnnotations;

namespace VDSTrucking.Models
{
    public class Truck
    {
        public int TruckID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; }
    }
}
