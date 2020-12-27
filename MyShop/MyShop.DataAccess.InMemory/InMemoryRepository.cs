using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class InMemoryRepository<T> where T : BaseEntity
    {
        ObjectCache cach = MemoryCache.Default;
        List<T> items;
        string className;
        
        public InMemoryRepository()
        {
            className = typeof(T).Name;
            items = cach[className] as List<T>;

            if (items == null)
                items = new List<T>();
        }
        
        public void Commit()
        {
            cach[className] = items;
        } 

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T itemToUpdate = items.Find(i => i.Id == t.Id);
            if (itemToUpdate != null)
                itemToUpdate = t;
            else
                throw new Exception("Item Not Found");
        }

        public void Delete(string id)
        {
            T itemToDelete = items.Find(i => i.Id == id);
            if (itemToDelete != null)
                items.Remove(itemToDelete);
            else
                throw new Exception("Item Not Found");
        }

        public T Find (string id)
        {
            T itemToFind = items.Find(i => i.Id == id);
            if (itemToFind != null)
                return itemToFind;
            else
                throw new Exception("Item Not Found");
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }






    }
}
