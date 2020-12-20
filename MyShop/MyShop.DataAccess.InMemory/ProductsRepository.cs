using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductsRepository
    {
        ObjectCache cach = MemoryCache.Default;
        List<Products> product;

        public ProductsRepository()
        {
            product = cach["product"] as List<Products>;

            if (product == null)
                product = new List<Products>();
        }

        public void Commit()
        {
            cach["product"] = product;
        }

        public void Insert(Products p)
        {
            product.Add(p);
        }

        public void Update(Products p)
        {
            Products productToUpdate = product.Find(f => f.Id == p.Id);

            if(productToUpdate != null)
            {
                productToUpdate = p;
            }else
            {
                throw new Exception("Not Found");
            }
        }

        public Products Find (string id)
        {
            Products productToFind = product.Find(f => f.Id == id);

            if (productToFind != null)
                return productToFind;
            else
                throw new Exception("Not Found");
        }

        public IQueryable<Products> Collection()
        {
            return product.AsQueryable();
        }
        

        public void Delete (string id)
        {
            Products productToDelete = product.Find(f => f.Id == id);

            if (productToDelete != null)
                product.Remove(productToDelete);
            else
                throw new Exception("Not Found");
        } 

    }
}
