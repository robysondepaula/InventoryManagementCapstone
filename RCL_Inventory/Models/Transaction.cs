using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required(ErrorMessage = "Please choose the Category Name.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter the Product Name.")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
