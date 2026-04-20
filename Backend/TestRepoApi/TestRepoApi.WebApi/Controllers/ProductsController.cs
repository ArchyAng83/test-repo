using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestRepoApi.WebApi.Models;
using TestRepoApi.WebApi.Services.Implementations;

namespace TestRepoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var products = await productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product is null)
            {
                return NotFound(product);
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] Product product)
        {
            var success = await productService.CreateProductAsync(product);

            if (!success)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product)
        {
            var success = await productService.UpdateProductAsync(product);

            if (!success)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync(int id)
        {
            var product = await productService.GetProductByIdAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            var success = await productService.DeleteProductAsync(id);

            if (!success)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
