using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductsCategoriesRepository
    {
        ObjectCache cach = MemoryCache.Default;
        List<ProductsCategories> productCategory;

        public ProductsCategoriesRepository()
        {
            productCategory = cach["productCategory"] as List<ProductsCategories>;

            if (productCategory == null)
                productCategory = new List<ProductsCategories>();
        }

        public void Commit()
        {
            cach["productCategory"] = productCategory;
        }

        public void Insert(ProductsCategories p)
        {
            productCategory.Add(p);
        }

        public void Update(ProductsCategories p)
        {
            ProductsCategories productsCategoryToUpdate = productCategory.Find(f => f.Id == p.Id);

            if (productsCategoryToUpdate != null)
            {
                productsCategoryToUpdate = p;
            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public ProductsCategories Find(string id)
        {
            ProductsCategories productCategoryToFind = productCategory.Find(f => f.Id == id);

            if (productCategoryToFind != null)
                return productCategoryToFind;
            else
                throw new Exception("Not Found");
        }

        public IQueryable<ProductsCategories> Collection()
        {
            return productCategory.AsQueryable();
        }


        public void Delete(string id)
        {
            ProductsCategories productCategoryToDelete = productCategory.Find(f => f.Id == id);

            if (productCategoryToDelete != null)
                productCategory.Remove(productCategoryToDelete);
            else
                throw new Exception("Not Found");
        }
    }
}
