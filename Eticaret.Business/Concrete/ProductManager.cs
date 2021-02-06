using Eticaret.Business.Abstract;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete;
using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _productRepository.GetProductByName(name);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }
    }
}
