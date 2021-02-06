using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Eticaret.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public async Task<Product> CreateProduct(Product product)
        {
            using (var EticaretDbContext = new EticaretDbContext())
            {
                EticaretDbContext.Products.Add(product);
                await EticaretDbContext.SaveChangesAsync();
                return product;
            }
        }

        public async Task DeleteProduct(int id)
        {
            using (var EticaretDbContext = new EticaretDbContext())
            {
                var delProduct =await GetProductById(id);
                EticaretDbContext.Products.Remove(delProduct);
                await EticaretDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            using (var EticaretDbContext=new EticaretDbContext())
            {
                return await EticaretDbContext.Products.ToListAsync();
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            using (var EticaretDbContext = new EticaretDbContext())
            {
                return await EticaretDbContext.Products.FindAsync(id);
            }
        }

        public async Task<Product> GetProductByName(string name)
        {
            using (var EticaretDbContext = new EticaretDbContext())
            {
                return await EticaretDbContext.Products.FirstOrDefaultAsync(x=>x.Name.ToLower()==name.ToLower());
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            using (var EticaretDbContext = new EticaretDbContext())
            {
                EticaretDbContext.Products.Update(product);
                await EticaretDbContext.SaveChangesAsync();
                return product;
            }
        }
    }
}
