using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class Transaction
    {
        [Key]
        [DisplayName("Transaction ID")]
        public int TransactionId { get; set; }
        [DisplayName("Create Date")]
        public DateTime Date { get; set; }
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }
        [DisplayName("Product ID")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Transaction Type ID")]
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        [DisplayName("Supplier ID")]
        public int SupplierId { get; set;}
        public Supplier Supplier { get; set; }
        
    }
}
