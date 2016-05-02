using OnlineStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entity.Database.ProductRepository
{
    public interface IProductRepository
    {
       Task<Product> InsertAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(Product prodcut);
        IQueryable<Product> GetAll();
    }
}
