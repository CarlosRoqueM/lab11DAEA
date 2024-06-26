﻿using Microsoft.EntityFrameworkCore;

namespace lab11DAEA.Models
{
    public class DataContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Product> Products { get; set; }

        //Data Source= LAB1504-04\\SQLEXPRESS; Initial Catalog=lab11;" + "User Id = carlos; Password=123456

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=A\\SQLEXPRESS; " +  "Initial Catalog=lab14;" + "Integrated Security=True;trustservercertificate=True");
        }

        public DbSet<lab11DAEA.Models.Customer> Customer { get; set; } = default! ; 
    }
}
