namespace lab11DAEA.Models.Request
{
    public class CustomerUpdateRequest
    {
        public int id { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; } = string.Empty;
    }
}
