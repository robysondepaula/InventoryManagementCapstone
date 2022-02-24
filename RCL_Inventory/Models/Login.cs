using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        [Required(ErrorMessage ="Enter your login.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }


    }
}
