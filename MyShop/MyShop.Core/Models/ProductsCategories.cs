using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductsCategories
    {
        public string  Id { get; set; }
        public string  Category { get; set; }

        public ProductsCategories()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
