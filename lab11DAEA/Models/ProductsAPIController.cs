using lab11DAEA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public Product InsertProduct(ProductInsertRequest request)
        {
            Product product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };
            datacontext.Products.Add(product);
            datacontext.SaveChanges();

            return product;
        }

        [HttpPost]
        public void Delete([FromBody] ProductDeleteRequest request)
        {
            //Logica
        }

        [HttpPut]
        public void Update([FromBody] ProductUpdateRequest request)
        {
            //Logica
        }

    }
}
