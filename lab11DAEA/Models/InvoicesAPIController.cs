using lab11DAEA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab11DAEA.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesAPIController : ControllerBase
    {
        [HttpPost]
        public void Insert([FromBody] InvoiceInsertRequest request)
        {
            
        }
    }
}
