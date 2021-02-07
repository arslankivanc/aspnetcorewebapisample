using Eticaret.Business.Abstract;
using Eticaret.Business.Concrete;
using Eticaret.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.API.Controllers
{
    /// <summary>
    /// Products Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService productService;
        /// <summary>
        /// Product Service Dependency Injection
        /// </summary>
        /// <param name="_productService"></param>
        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        ///     Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get()
        {
            var products=await productService.GetAllProducts();
            return Ok(products);
        }
        /// <summary>
        /// Get Product With Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product= await productService.GetProductById(id);
            if (product!=null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        /// <summary>
        /// Get Product with name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await productService.GetProductByName(name);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            var create =await productService.CreateProduct(product);
            return CreatedAtAction("Get", new { id = create.Id }, create);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            if (await productService.GetProductById(product.Id)!=null)
            {
                return Ok(await productService.UpdateProduct(product));
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Product With Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await productService.GetProductById(id) != null)
            {
                await productService.DeleteProduct(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
