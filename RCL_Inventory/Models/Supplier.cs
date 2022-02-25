using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RCL_Inventory.Models
{
    public class Supplier
    {

        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Please, need to write Supplier Name.")]
        public string Name { get; set; }


        [Required]
        [Range(0000000000, 9999999999, ErrorMessage = "Please, write a number of 9 digits.")]
        public string Telephone { get; set; }

        [Required]
        [Range(0000000000, 9999999999, ErrorMessage = "Please, write a number of 9 digits.")]
        public string AccountNumber { get; set; }

        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
