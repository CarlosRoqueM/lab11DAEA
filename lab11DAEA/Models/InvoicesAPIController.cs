using lab11DAEA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab11DAEA.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesAPIController : ControllerBase
    {
        private readonly DataContext datacontext;

        public InvoicesAPIController(DataContext context)
        {
            datacontext = context;
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> InsertInvoice([FromBody] InvoiceInsertRequest request)
        {
            var customer = await datacontext.Customers.FindAsync(request.customerId);

            if (customer == null)
            {
                return NotFound();
            }

            Invoice invoice = new();
            invoice.id = request.customerId;
            invoice.date= request.date;
            invoice.invoiceNumbre = request.invoiceNumbre;
            invoice.total = request.total;
            invoice.Customer = customer;

            datacontext.Invoices.Add(invoice);
            await datacontext.SaveChangesAsync();

            return CreatedAtAction("InsertInvoice", new { id = invoice.id }, invoice);
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> InsertInvoiceDetail([FromBody] RequestInvoiceV4 requestInvoiceV4)
        {
            //Validando que la factura exista
            var invoice = await _context.Invoices.FindAsync(requestInvoiceV4.InvoiceID);

            if (invoice == null)
            {
                return NotFound();
            }

            var details = requestInvoiceV4.DetailV1s.ToList();

            //Para capturar los nuevos details
            List<Detail> newDetails = new();

            foreach (var invoiceDetail in details)
            {
                Detail detail = new();

                detail.InvoiceID = invoice.InvoiceID;

                int idProduct = invoiceDetail.ProductID;
                var product = await _context.Products.FindAsync(idProduct);
                if (product == null)
                {
                    return Problem();
                }

                detail.ProductID = invoiceDetail.ProductID;
                detail.Price = product.Price;
                detail.Amount = invoiceDetail.Amount;
                detail.SubTotal = detail.Amount * detail.Price;

                _context.Details.Add(detail);

                newDetails.Add(detail);
                invoice.Total += detail.SubTotal;
            }

            //Actualizar el total de la factura
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("InsertInvoiceDetail", new { id = invoice.InvoiceID }, newDetails);
        }
    }
}
}
