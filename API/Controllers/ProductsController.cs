using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IProductRepository repo) : ControllerBase
    {



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct()
        {
            return Ok(await repo.GetProductsAsync());
        }




        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product == null)
                return NotFound($"No product found with ID {id}.");

            return product;
        }





        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.AddProduct(product);

            if (await repo.SaveChangesAsync())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }
            return BadRequest("Failed to create product. Please check the provided data and try again.");
        }





        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (product.Id != id)
                return BadRequest($"The provided product ID ({product.Id}) does not match the ID in the route ({id}).");

            if (!ProductExists(id))
                return BadRequest($"Cannot update product. No product found with ID {id}.");

            repo.UpdateProduct(product);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest("An error occurred while updating the product. Please try again.");
        }





        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            if (product == null)
                return NotFound($"No product found with ID {id}.");

            repo.DeleteProduct(product);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }
            return BadRequest($"Failed to delete the product with ID {id}. Please try again.");
        }





        private bool ProductExists(int id)
        {
            return repo.ProductExists(id);
        }
    }
}
