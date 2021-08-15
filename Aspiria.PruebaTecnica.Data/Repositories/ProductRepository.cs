using Aspiria.PruebaTecnica.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspiria.PruebaTecnica.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int Id)
        {
            var toDelete = context.Products.Where(product => product.Id == Id).FirstOrDefault();
            if(toDelete != null)
            {
                context.Remove(toDelete);
                context.SaveChanges();
            }
            return true;
        }

        public Product Find(int Id)
        {
            return context.Products.FirstOrDefault(product => product.Id.Equals(Id));
        }

        public IQueryable<Product> Find(string Pattern)
        {
            return context.Products
                .Where(product => ($"{product.Name} {product.Description}").ToLowerInvariant().Contains(Pattern));
        }

        public bool Save(Product entity)
        {
            if(entity.Id > 0)
            {
                context.Products.Update(entity);
            }
            else
            {
                context.Products.Add(entity);
            }
            var entries =context.SaveChanges();
            return entries > 0;
        }

        public bool Update(Product entity)
        {
            return this.Save(entity);
        }
    }
}
