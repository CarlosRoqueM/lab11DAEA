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
        public async Task<ActionResult<Customer>> InsertCustomer(CustomerInsertRequest request)
        {
            Customer customer = new();
            customer.documentNumber = request.documentNumber;
            customer.firstName = request.firstName;
            customer.lastName = request.lastName;
            customer.email = request.email;
            datacontext.Add(customer);
            datacontext.SaveChanges();
            return customer;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(CustomerDeleteRequest request)
        {
            var id = request.id;

            if (datacontext.Customers == null)
            {
                return NotFound();
            }
            var customer = await datacontext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.IsDeleted = true;
            datacontext.Customers.Update(customer);
            await datacontext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(CustomerUpdateRequest request)
        {
            var customer = await datacontext.Customers.FindAsync(request.id);

            if (customer == null || customer.IsDeleted == true)
            {
                return NotFound();
            }

            customer.documentNumber = request.documentNumber;
            customer.email = request.email;

            datacontext.Customers.Update(customer);
            await datacontext.SaveChangesAsync();

            return CreatedAtAction("Update Customer", new { id = customer.id }, customer);
        }
    }

}
