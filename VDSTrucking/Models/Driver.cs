using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VDSTrucking.Models
{
    public class Driver
    {
        public int DriverID { get; set; }

        [Required]
        [StringLength(50, MinimumLength =2)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name ="Middle Name")]
        public string MiddleName { get; set; }
    }
}
