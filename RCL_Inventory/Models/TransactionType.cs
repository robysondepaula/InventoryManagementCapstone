using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RCL_Inventory.Models
{
    public class TransactionType
    {
       [Key]
        public int TransactionTypeId { get; set; }
        [Required(ErrorMessage = "Please, need to write Country Name.")]
        public string Name { get; set; }

    }
}
