namespace lab11DAEA.Models
{
    public class Detail
    {
        public int id { get; set; }

        public Product Product { get; set; }
        public int ProductsId { get; set; }

        public Invoice Invoice { get; set; }
        public int InvoicesId { get; set; }

        public int amount { get; set; }
        public float price {  get; set; }
        public float subTotal { get; set; }
    }
}
