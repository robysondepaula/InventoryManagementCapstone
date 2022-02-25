using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RCL_Inventory.Models
{
    public class Address
    {

        [Key]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Please, need to write Country Name.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please, need to write City Name.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please, need to write Province Name.")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Please, need to write Postal Code.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please, need to write Street Name.")]
        public string Street { get; set; }


    }
}
