using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Core.Entities;
using System.Data.Entity;

namespace OnlineStore.Entity.Database.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _context;

        public ProductRepository()
        {
            _context = new StoreDbContext();
        }

        public async Task DeleteAsync(Product prodcut)
        {
            var dbProduct = _context.Products.Find(prodcut.Id);
            _context.Products.Remove(dbProduct);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public async Task<Product> InsertAsync(Product product)
        {
            product = _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
