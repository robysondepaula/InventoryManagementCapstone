using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class InventoryContext : DbContext
    {

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>().HasData(
           new Category { CategoryId = 1, Name = "Furniture" },
           new Category { CategoryId = 2, Name = "Office Equipment" },
           new Category { CategoryId = 3, Name = "Repairs and Maintenance" });

            modelBuilder.Entity<Product>().HasData(
            
                new Product
                {
                    ProductId = 1,
                    Name = "Table",
                    Description = "",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Pencil",
                    Description = "",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Pen",
                    Description = "",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Pencil",
                    Description = "",
                    CategoryId = 3
                });


        }
    }
}