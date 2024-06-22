using lab11DAEA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab11DAEA.Models
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase

    {
        private readonly DataContext datacontext;

        public CustomerAPIController(DataContext context)
        {
            datacontext = context;
        }

        [HttpPost]
        public Customer insertCustomer(CustomerInsertRequest request)
        {
            Customer customer = new Customer
            {
                documentNumber = request.documentNumber,
                lastName = request.lastName,
                firstName = request.firstName
            };

            datacontext.Add(customer);
            datacontext.SaveChanges();
            return customer;
        }

        [HttpDelete]
        public void Delete([FromBody] CustomerDeleteRequest request)
        {
            // Lógica para eliminar el cliente de la base de datos
        }

        [HttpPut]
        public void Update([FromBody] CustomerUpdateRequest request)
        {
            // Lógica para actualizar el cliente en la base de datos
        }

    }
}
