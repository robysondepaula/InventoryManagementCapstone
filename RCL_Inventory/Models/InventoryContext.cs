﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCL_Inventory.Models
{
    public class InventoryContext : DbContext
    {

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Cellphone" },
                new Category { CategoryId = 2, Name = "TV" },
                new Category { CategoryId = 3, Name = "Laptop"},
                new Category { CategoryId = 4, Name = "Gaming Console" },
                new Category { CategoryId = 5, Name = "Tablet" },
                new Category { CategoryId = 6, Name = "Home Appliances" }
           );

            modelBuilder.Entity<Product>().HasData(           
                new Product { ProductId = 1, Name = "LG OLED TV", Description = "55 inch 4K OLED Smart TV", CategoryId = 2 },
                new Product { ProductId = 2, Name = "Samsung QLED TV", Description = "75 inch 8K QLED Smart TV", CategoryId = 2  },
                new Product { ProductId = 3, Name = "Samsung Smart TV", Description = "65 inch 4K Smart TV", CategoryId = 2  },
                new Product { ProductId = 4, Name = "Sony X80J TV", Description = "75 inch 4K HDR LED Smart TV", CategoryId = 2  },
                new Product { ProductId = 5, Name = "Samsung Galaxy S22", Description = "6.1 inch display, 1080x2340 pixels, 50MP Camera, 8GB RAM, 250GB, Android 12", CategoryId = 1  },
                new Product { ProductId = 6, Name = "Samsung Galaxy S21", Description = "6.4 inch display, 1080x2400 pixels, 12MP Camera, 8GB RAM, 500GB, Android 12", CategoryId = 1 },
                new Product { ProductId = 7, Name = "Iphone 13 Pro Max", Description = "6.7 inch display, 1284x2778 pixels, 12MP Camera, 6GB RAM, 512GB, iOS 15", CategoryId = 1 },
                new Product { ProductId = 8, Name = "Iphone 13", Description = "6.1 inch display, 1170x2532 pixels, 12MP Camera, 4GB RAM, 128GB, iOS 15", CategoryId = 1 },
                new Product { ProductId = 9, Name = "Xiaomi Redmi Note 11", Description = "6.43 inch display, 1080x2400 pixels, 50MP Camera, 6GB RAM, 256GB, Android 11", CategoryId = 1 },
                new Product { ProductId = 10, Name = "MSI Laptop", Description = "CPU Intel i7-7700M, 16GB RAM, 500GB SSD, 1TB HDD, GPU GeForce 3060RTX, 17.3 inch display", CategoryId = 3 },
                new Product { ProductId = 11, Name = "Apple MacBook Pro", Description = "8-Core CPU, 16GB RAM, 250GB SSD, 500GB HD, GPU 14-core, 14 inch display", CategoryId = 3},
                new Product { ProductId = 12, Name = "Alienware Laptop", Description = "CPU Intel i9-9500M, 32GB RAM, 500GB SSD, 1TB HDD, GPU GeForce 3090RTX, 17.3 inch display", CategoryId = 3 },
                new Product { ProductId = 13, Name = "Apple MacBook Pro", Description = "8-Core CPU, 32GB RAM, 500GB SSD, 1TB HD, GPU 14-core, 16 inch display", CategoryId = 3 },
                new Product { ProductId = 14, Name = "Xbox Series X", Description = "Xbox Series X gaming console, with 2 wireless controllers", CategoryId = 4 },
                new Product { ProductId = 15, Name = "PlayStation 5", Description = "PlayStation 5 gaming console, with 1 wireless controller", CategoryId = 4 },
                new Product { ProductId = 16, Name = "Apple Ipad", Description = "Ipad 10.2 display, 6GB RAM, 500GB, 12MP Camera, iOS 15", CategoryId = 5 },
                new Product { ProductId = 17, Name = "Samsung Galaxy Tab A7", Description = "8.7 inch display, 32GB, Android 12", CategoryId = 5 },
                new Product { ProductId = 18, Name = "LG Microwave NeoChef", Description = "1.5cu, Countertop Microwave with Smart Inverter and EasyClean", CategoryId = 6 },
                new Product { ProductId = 19, Name = "LG Microwave OTR", Description = "1.7cu, Over-the-Range Microwave Oven with EasyClean", CategoryId = 6 },
                new Product { ProductId = 20, Name = "Insignia Air Fryer", Description = "4.8L capacity, Stainless Steel, Hot air, 60 minutes timer", CategoryId = 6 },
                new Product { ProductId = 21, Name = "Hamilton Beach Toaster", Description = "2-Slice toaster in chrome, high-lift boost toast function, Extra-wide slots", CategoryId = 6 },
                new Product { ProductId = 22, Name = "Nespresso Vertuo Coffee", Description = "Nespresso Vertuo Coffee & Espresso Machine by DeLonghi w/ Aeroccino Milk Frother, Black", CategoryId = 6 }
                );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, Name = "Samsung", Telephone = "544222333", AccountNumber = "121314151", AddressId = 1 },
                new Supplier { SupplierId = 2, Name = "LG", Telephone = "543242313", AccountNumber = "121314152", AddressId = 2 },
                new Supplier { SupplierId = 3, Name = "Sony", Telephone = "554282343", AccountNumber = "121314153", AddressId = 3 },
                new Supplier { SupplierId = 4, Name = "Apple", Telephone = "545132133", AccountNumber = "121314154", AddressId = 4 },
                new Supplier { SupplierId = 5, Name = "Xiaomi", Telephone = "549282383", AccountNumber = "121314155", AddressId = 5 },
                new Supplier { SupplierId = 6, Name = "MSI", Telephone = "584232331", AccountNumber = "121314156", AddressId = 6 },
                new Supplier { SupplierId = 7, Name = "Alienware", Telephone = "543212773", AccountNumber = "121314157", AddressId = 7 },
                new Supplier { SupplierId = 8, Name = "Microsoft", Telephone = "523878337", AccountNumber = "121314158", AddressId = 8 },
                new Supplier { SupplierId = 9, Name = "Insignia", Telephone = "540202330", AccountNumber = "121314159", AddressId = 9 },
                new Supplier { SupplierId = 10, Name = "Hamilton", Telephone = "544262131", AccountNumber = "121314110", AddressId = 10 },
                new Supplier { SupplierId = 11, Name = "Nespresso", Telephone = "543212321", AccountNumber = "121314111", AddressId = 11 }
                );

            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, Country = "Canada", City = "Toronto", Province = "ON", PostalCode = "N2K 3P4", Street = "32 Dundas Street" },
                new Address { AddressId = 2, Country = "Canada", City = "Vancouver", Province = "BC", PostalCode = "P2C 3P5", Street = "99 King Street" },
                new Address { AddressId = 3, Country = "Canada", City = "Calgary", Province = "AL", PostalCode = "U2M 5C3", Street = "45 Mcdonald Avenue" },
                new Address { AddressId = 4, Country = "Canada", City = "Kitchener", Province = "ON", PostalCode = "Y2K 3O4", Street = "11 Westwood Drive" },
                new Address { AddressId = 5, Country = "Canada", City = "Waterloo", Province = "ON", PostalCode = "C2T 5P1", Street = "65 Queen Street" },
                new Address { AddressId = 6, Country = "Canada", City = "Toronto", Province = "ON", PostalCode = "N4Y 1C2", Street = "32 Thompson Avenue" },
                new Address { AddressId = 7, Country = "Canada", City = "Montreal", Province = "QC", PostalCode = "N2K 3P4", Street = "22 Atwater Avenue" },
                new Address { AddressId = 8, Country = "Canada", City = "Calgary", Province = "AL", PostalCode = "T2M 5V3", Street = "21 International Avenue" },
                new Address { AddressId = 9, Country = "Canada", City = "Kitchener", Province = "ON", PostalCode = "U2K 3U4", Street = "66 Western Road" },
                new Address { AddressId = 10, Country = "Canada", City = "Waterloo", Province = "ON", PostalCode = "P2T 5C1", Street = "49 Erb Street" },
                new Address { AddressId = 11, Country = "Canada", City = "Toronto", Province = "ON", PostalCode = "C4Y 1T2", Street = "38 Eastern Avenue" }
                );


            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { TransactionTypeId = 1, Name = "Purchase" },
                new TransactionType { TransactionTypeId = 2, Name = "Sale" },
                new TransactionType { TransactionTypeId = 3, Name = "Loss" }
                );

        }
    }
}