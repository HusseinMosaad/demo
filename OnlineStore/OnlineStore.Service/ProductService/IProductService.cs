using OnlineStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.ProductService
{
    public interface IProductService
    {
        Task<Product> SaveProductAsync(Product product);
        Task DeleteAsync(Product prodcut);
        ICollection<Product> GetAll();
    }
}
