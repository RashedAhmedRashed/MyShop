using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Products
    {
        public string Id { get; set; }

        [StringLength(20)]
        [Display(Description ="Product Name")]
        public string  Name { get; set; }

        [Range(0,1000)]
        public int Price { get; set; }
        public string Category { get; set; }
        public string  Description { get; set; }

        public Products()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
