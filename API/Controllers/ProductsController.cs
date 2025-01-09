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
    public class ProductsController(IGenericRepository<Product> repo ) : ControllerBase
    {



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProduct(string? brand, 
            string? type, string? sort)
        {
            return Ok(await repo.ListAllAsync());
        }




        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
                return NotFound($"No product found with ID {id}.");

            return product;
        }





        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repo.Add(product);

            if (await repo.SaveAllAsync())
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

            repo.Update(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest("An error occurred while updating the product. Please try again.");
        }





        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await repo.GetByIdAsync(id);

            if (product == null)
                return NotFound($"No product found with ID {id}.");

            repo.Remove(product);

            if (await repo.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest($"Failed to delete the product with ID {id}. Please try again.");
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            return Ok();
        }

        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            return Ok();
        }



        private bool ProductExists(int id)
        {
            return repo.Exists(id);
        }
    }
}
