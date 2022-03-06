﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCL_Inventory.Models;

namespace RCL_Inventory.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RCL_Inventory.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Toronto",
                            Country = "Canada",
                            PostalCode = "N2K 3P4",
                            Province = "ON",
                            Street = "32 Dundas Street"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Vancouver",
                            Country = "Canada",
                            PostalCode = "P2C 3P5",
                            Province = "BC",
                            Street = "99 King Street"
                        },
                        new
                        {
                            AddressId = 3,
                            City = "Calgary",
                            Country = "Canada",
                            PostalCode = "U2M 5C3",
                            Province = "AL",
                            Street = "45 Mcdonald Avenue"
                        },
                        new
                        {
                            AddressId = 4,
                            City = "Kitchener",
                            Country = "Canada",
                            PostalCode = "Y2K 3O4",
                            Province = "ON",
                            Street = "11 Westwood Drive"
                        },
                        new
                        {
                            AddressId = 5,
                            City = "Waterloo",
                            Country = "Canada",
                            PostalCode = "C2T 5P1",
                            Province = "ON",
                            Street = "65 Queen Street"
                        },
                        new
                        {
                            AddressId = 6,
                            City = "Toronto",
                            Country = "Canada",
                            PostalCode = "N4Y 1C2",
                            Province = "ON",
                            Street = "32 Thompson Avenue"
                        },
                        new
                        {
                            AddressId = 7,
                            City = "Montreal",
                            Country = "Canada",
                            PostalCode = "N2K 3P4",
                            Province = "QC",
                            Street = "22 Atwater Avenue"
                        },
                        new
                        {
                            AddressId = 8,
                            City = "Calgary",
                            Country = "Canada",
                            PostalCode = "T2M 5V3",
                            Province = "AL",
                            Street = "21 International Avenue"
                        },
                        new
                        {
                            AddressId = 9,
                            City = "Kitchener",
                            Country = "Canada",
                            PostalCode = "U2K 3U4",
                            Province = "ON",
                            Street = "66 Western Road"
                        },
                        new
                        {
                            AddressId = 10,
                            City = "Waterloo",
                            Country = "Canada",
                            PostalCode = "P2T 5C1",
                            Province = "ON",
                            Street = "49 Erb Street"
                        },
                        new
                        {
                            AddressId = 11,
                            City = "Toronto",
                            Country = "Canada",
                            PostalCode = "C4Y 1T2",
                            Province = "ON",
                            Street = "38 Eastern Avenue"
                        });
                });

            modelBuilder.Entity("RCL_Inventory.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Cellphones",
                            Name = "Cellphone"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Television",
                            Name = "TV"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Portatil Computer",
                            Name = "Laptop"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "PlayStation, Xbox or Wii console",
                            Name = "Gaming Console"
                        },
                        new
                        {
                            CategoryId = 5,
                            Description = "Ipad, Galaxy note and others.",
                            Name = "Tablet"
                        },
                        new
                        {
                            CategoryId = 6,
                            Description = "Echo Dot, Google Cast, Alexia Fire, and others.",
                            Name = "Home Appliances"
                        });
                });

            modelBuilder.Entity("RCL_Inventory.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Brand = "LG",
                            CategoryId = 2,
                            Description = "55 inch 4K OLED Smart TV",
                            Name = "LG OLED TV"
                        },
                        new
                        {
                            ProductId = 2,
                            Brand = "Samsung",
                            CategoryId = 2,
                            Description = "75 inch 8K QLED Smart TV",
                            Name = "Samsung QLED TV"
                        },
                        new
                        {
                            ProductId = 3,
                            Brand = "Samsung",
                            CategoryId = 2,
                            Description = "65 inch 4K Smart TV",
                            Name = "Samsung Smart TV"
                        },
                        new
                        {
                            ProductId = 4,
                            Brand = "Sony",
                            CategoryId = 2,
                            Description = "75 inch 4K HDR LED Smart TV",
                            Name = "Sony X80J TV"
                        },
                        new
                        {
                            ProductId = 5,
                            Brand = "Samsung",
                            CategoryId = 1,
                            Description = "6.1 inch display, 1080x2340 pixels, 50MP Camera, 8GB RAM, 250GB, Android 12",
                            Name = "Samsung Galaxy S22"
                        },
                        new
                        {
                            ProductId = 6,
                            Brand = "Samsung",
                            CategoryId = 1,
                            Description = "6.4 inch display, 1080x2400 pixels, 12MP Camera, 8GB RAM, 500GB, Android 12",
                            Name = "Samsung Galaxy S21"
                        },
                        new
                        {
                            ProductId = 7,
                            Brand = "Apple",
                            CategoryId = 1,
                            Description = "6.7 inch display, 1284x2778 pixels, 12MP Camera, 6GB RAM, 512GB, iOS 15",
                            Name = "Iphone 13 Pro Max"
                        },
                        new
                        {
                            ProductId = 8,
                            Brand = "Apple",
                            CategoryId = 1,
                            Description = "6.1 inch display, 1170x2532 pixels, 12MP Camera, 4GB RAM, 128GB, iOS 15",
                            Name = "Iphone 13"
                        },
                        new
                        {
                            ProductId = 9,
                            Brand = "Xiaomi",
                            CategoryId = 1,
                            Description = "6.43 inch display, 1080x2400 pixels, 50MP Camera, 6GB RAM, 256GB, Android 11",
                            Name = "Xiaomi Redmi Note 11"
                        },
                        new
                        {
                            ProductId = 10,
                            Brand = "MSI",
                            CategoryId = 3,
                            Description = "CPU Intel i7-7700M, 16GB RAM, 500GB SSD, 1TB HDD, GPU GeForce 3060RTX, 17.3 inch display",
                            Name = "MSI Laptop"
                        },
                        new
                        {
                            ProductId = 11,
                            Brand = "Apple",
                            CategoryId = 3,
                            Description = "8-Core CPU, 16GB RAM, 250GB SSD, 500GB HD, GPU 14-core, 14 inch display",
                            Name = "Apple MacBook Pro"
                        },
                        new
                        {
                            ProductId = 12,
                            Brand = "Alieware",
                            CategoryId = 3,
                            Description = "CPU Intel i9-9500M, 32GB RAM, 500GB SSD, 1TB HDD, GPU GeForce 3090RTX, 17.3 inch display",
                            Name = "Alienware Laptop"
                        },
                        new
                        {
                            ProductId = 13,
                            Brand = "Apple",
                            CategoryId = 3,
                            Description = "8-Core CPU, 32GB RAM, 500GB SSD, 1TB HD, GPU 14-core, 16 inch display",
                            Name = "Apple MacBook Pro"
                        },
                        new
                        {
                            ProductId = 14,
                            Brand = "Microsoft",
                            CategoryId = 4,
                            Description = "Xbox Series X gaming console, with 2 wireless controllers",
                            Name = "Xbox Series X"
                        },
                        new
                        {
                            ProductId = 15,
                            Brand = "Sony",
                            CategoryId = 4,
                            Description = "PlayStation 5 gaming console, with 1 wireless controller",
                            Name = "PlayStation 5"
                        },
                        new
                        {
                            ProductId = 16,
                            Brand = "Apple",
                            CategoryId = 5,
                            Description = "Ipad 10.2 display, 6GB RAM, 500GB, 12MP Camera, iOS 15",
                            Name = "Apple Ipad"
                        },
                        new
                        {
                            ProductId = 17,
                            Brand = "Samsung",
                            CategoryId = 5,
                            Description = "8.7 inch display, 32GB, Android 12",
                            Name = "Samsung Galaxy Tab A7"
                        },
                        new
                        {
                            ProductId = 18,
                            Brand = "LG",
                            CategoryId = 6,
                            Description = "1.5cu, Countertop Microwave with Smart Inverter and EasyClean",
                            Name = "LG Microwave NeoChef"
                        },
                        new
                        {
                            ProductId = 19,
                            Brand = "LG",
                            CategoryId = 6,
                            Description = "1.7cu, Over-the-Range Microwave Oven with EasyClean",
                            Name = "LG Microwave OTR"
                        },
                        new
                        {
                            ProductId = 20,
                            Brand = "Insignia",
                            CategoryId = 6,
                            Description = "4.8L capacity, Stainless Steel, Hot air, 60 minutes timer",
                            Name = "Insignia Air Fryer"
                        },
                        new
                        {
                            ProductId = 21,
                            Brand = "Hamilton",
                            CategoryId = 6,
                            Description = "2-Slice toaster in chrome, high-lift boost toast function, Extra-wide slots",
                            Name = "Hamilton Beach Toaster"
                        },
                        new
                        {
                            ProductId = 22,
                            Brand = "Nespresso",
                            CategoryId = 6,
                            Description = "Nespresso Vertuo Coffee & Espresso Machine by DeLonghi w/ Aeroccino Milk Frother, Black",
                            Name = "Nespresso Vertuo Coffee"
                        });
                });

            modelBuilder.Entity("RCL_Inventory.Models.Roler", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roler");
                });

            modelBuilder.Entity("RCL_Inventory.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.HasIndex("AddressId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            AccountNumber = "121314151",
                            AddressId = 1,
                            Name = "Samsung",
                            Telephone = "544222333"
                        },
                        new
                        {
                            SupplierId = 2,
                            AccountNumber = "121314152",
                            AddressId = 2,
                            Name = "LG",
                            Telephone = "543242313"
                        },
                        new
                        {
                            SupplierId = 3,
                            AccountNumber = "121314153",
                            AddressId = 3,
                            Name = "Sony",
                            Telephone = "554282343"
                        },
                        new
                        {
                            SupplierId = 4,
                            AccountNumber = "121314154",
                            AddressId = 4,
                            Name = "Apple",
                            Telephone = "545132133"
                        },
                        new
                        {
                            SupplierId = 5,
                            AccountNumber = "121314155",
                            AddressId = 5,
                            Name = "Xiaomi",
                            Telephone = "549282383"
                        },
                        new
                        {
                            SupplierId = 6,
                            AccountNumber = "121314156",
                            AddressId = 6,
                            Name = "MSI",
                            Telephone = "584232331"
                        },
                        new
                        {
                            SupplierId = 7,
                            AccountNumber = "121314157",
                            AddressId = 7,
                            Name = "Alienware",
                            Telephone = "543212773"
                        },
                        new
                        {
                            SupplierId = 8,
                            AccountNumber = "121314158",
                            AddressId = 8,
                            Name = "Microsoft",
                            Telephone = "523878337"
                        },
                        new
                        {
                            SupplierId = 9,
                            AccountNumber = "121314159",
                            AddressId = 9,
                            Name = "Insignia",
                            Telephone = "540202330"
                        },
                        new
                        {
                            SupplierId = 10,
                            AccountNumber = "121314110",
                            AddressId = 10,
                            Name = "Hamilton",
                            Telephone = "544262131"
                        },
                        new
                        {
                            SupplierId = 11,
                            AccountNumber = "121314111",
                            AddressId = 11,
                            Name = "Nespresso",
                            Telephone = "543212321"
                        });
                });

            modelBuilder.Entity("RCL_Inventory.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("RCL_Inventory.Models.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeId = 1,
                            Name = "Purchase"
                        },
                        new
                        {
                            TransactionTypeId = 2,
                            Name = "Sale"
                        },
                        new
                        {
                            TransactionTypeId = 3,
                            Name = "Loss"
                        });
                });

            modelBuilder.Entity("RCL_Inventory.Models.User", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("RolerRoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginID");

                    b.HasIndex("AddressId");

                    b.HasIndex("RolerRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RCL_Inventory.Models.Product", b =>
                {
                    b.HasOne("RCL_Inventory.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RCL_Inventory.Models.Supplier", b =>
                {
                    b.HasOne("RCL_Inventory.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("RCL_Inventory.Models.Transaction", b =>
                {
                    b.HasOne("RCL_Inventory.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCL_Inventory.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCL_Inventory.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("RCL_Inventory.Models.User", b =>
                {
                    b.HasOne("RCL_Inventory.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RCL_Inventory.Models.Roler", "Roler")
                        .WithMany()
                        .HasForeignKey("RolerRoleId");

                    b.Navigation("Address");

                    b.Navigation("Roler");
                });
#pragma warning restore 612, 618
        }
    }
}
