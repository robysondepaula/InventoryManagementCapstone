using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RCL_Inventory.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter the Product Name.")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose the Category Name.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
