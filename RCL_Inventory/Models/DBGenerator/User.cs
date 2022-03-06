using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RCL_Inventory.Models
{
    public class User
    {

        [Key]
        [DisplayName("Üser ID")]
        public int LoginID { get; set; }
        [Required(ErrorMessage = "Enter your login.")]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter your Role")]
        [DisplayName("Roler ID")]
        public int  RoleId { get; set; }
        public Roler Roler { get; set; }
        [DisplayName("Address ID")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}
