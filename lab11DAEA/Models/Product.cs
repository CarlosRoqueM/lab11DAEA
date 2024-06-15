using Microsoft.EntityFrameworkCore;

namespace lab11DAEA.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsDeleted { get; internal set; }
    }
}
