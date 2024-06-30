namespace lab11DAEA.Models.Request
{
    public class CustomerInsertRequest
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; } = string.Empty;

    }
}
