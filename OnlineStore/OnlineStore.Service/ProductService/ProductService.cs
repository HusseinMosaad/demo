using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Core.Entities;
using OnlineStore.Entity.Database.ProductRepository;
using OnlineStore.Core;

namespace OnlineStore.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task DeleteAsync(Product prodcut)
        {
            await _productRepository.DeleteAsync(prodcut);
        }

        public ICollection<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public async Task<Product> SaveProductAsync(Product product)
        {
            if (CheckIfProductExistBefore(product))
            {
                throw new OnlineStoreBusinessException("There is a product exist before with name " + product.Name);
            }

            if (product.IsNew)
            {
                return await _productRepository.InsertAsync(product);
            }
            return await _productRepository.UpdateAsync(product);
        }

        private bool CheckIfProductExistBefore(Product product)
        {
            return _productRepository.GetAll().Any(p => p.Id != product.Id && p.Name.ToLower() == product.Name.ToLower());
        }
    }
}
