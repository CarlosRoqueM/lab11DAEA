namespace lab11DAEA.Models
{
    public class Customer
    {
        public int id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string documentNumber { get; set; }
        public string email { get; set; } = string.Empty;
        public bool IsDeleted { get; internal set; }
    }
}
