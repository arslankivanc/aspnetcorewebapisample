using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task  DeleteProduct(int id);
    }
}
