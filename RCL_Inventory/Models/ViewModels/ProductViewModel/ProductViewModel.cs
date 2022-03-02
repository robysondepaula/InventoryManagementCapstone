using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models.ViewModels.ViewModelProduct
{
    public class ProductViewModel
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<Product> Products {get;set;}



    }
}
