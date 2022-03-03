using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace RCL_Inventory.Models
{
    public class Product
    {
        [Key]
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the Product Name.")]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose the Category Name.")]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }      
        public int? SupplierId { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
