using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RCL_Inventory.Models
{
    public class User
    {

        [Key]
        public int LoginID { get; set; }
        [Required(ErrorMessage = "Enter your login.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Enter your Role")]
        public string Role { get; set; }




    }
}
