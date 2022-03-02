using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RCL_Inventory.Models
{
    public class Address
    {

        [Key]
        [DisplayName("Address ID")]
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Please, need to write Country Name.")]
        [DisplayName("Address Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please, need to write City Name.")]
        [DisplayName("Address City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please, need to write Province Name.")]
        [DisplayName("Address Province")]
        public string Province { get; set; }
        [Required(ErrorMessage = "Please, need to write Postal Code.")]
        [DisplayName("Address Postal")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please, need to write Street Name.")]
        [DisplayName("Address Street")]
        public string Street { get; set; }


    }
}
