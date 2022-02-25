using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Please enter the Category Name.")]
        public int CategoryId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }

    }
}
