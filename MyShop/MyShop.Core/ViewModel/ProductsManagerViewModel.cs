using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ViewModel
{
    public class ProductsManagerViewModel
    {
        public Products  product { get; set; }
        public IEnumerable<ProductsCategories> productsCategories { get; set; }
    }
}
