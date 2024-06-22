namespace lab11DAEA.Models.Request
{
    public class InvoiceInsertRequest
    {
        public int customerId { get; set; }
        public Customer Customer { get; set; }


        public DateTime date { get; set; }
        public string invoiceNumbre { get; set; }
        public float total { get; set; }
    }
}
