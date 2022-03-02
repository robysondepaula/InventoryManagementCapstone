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



        public int CategoryId { get; set; }
        

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }

        public int SupplierId { get; set; }
    }
}
