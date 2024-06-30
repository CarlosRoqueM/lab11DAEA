using lab11DAEA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab11DAEA.Models
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        private readonly DataContext datacontext;

        public ProductsAPIController(DataContext context)
        {
            datacontext = context;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> InsertProduct([FromBody] ProductInsertRequest request)
        {
            Product product = new();
            product.Name = request.Name;
            product.Price = request.Price;

            if (datacontext.Products == null)
            {
                return Problem("Entity set 'MarketContext.Products'  is null.");
            }
            datacontext.Products.Add(product);
            await datacontext.SaveChangesAsync();

            return CreatedAtAction("Insert Product", new { id = product.id }, product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct( ProductDeleteRequest request)
        {
            var id = request.id;

            if (datacontext.Products == null)
            {
                return NotFound();
            }
            var product = await datacontext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsDeleted = false;
            datacontext.Products.Update(product);
            await datacontext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateProduct([FromBody] ProductUpdateRequest request)
        {
            var product = await datacontext.Products.FindAsync(request.id);

            if (product == null || product.IsDeleted == false)
            {
                return NotFound();
            }

            product.Price = request.Price;

            datacontext.Products.Update(product);
            await datacontext.SaveChangesAsync();

            return CreatedAtAction("Update Product", new { id = product.id}, product);
        }

    }
}
