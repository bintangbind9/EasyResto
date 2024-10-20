﻿// <auto-generated />
using System;
using EasyResto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyResto.Infrastructure.Migrations
{
    [DbContext(typeof(EasyRestoDbContext))]
    [Migration("20241021033232_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EasyResto.Domain.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("AppUser", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AppUserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUserRole", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.DiningTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("DiningTable", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("FoodCategory", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FoodCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodItemStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("FoodCategoryId");

                    b.HasIndex("FoodItemStatusId");

                    b.ToTable("FoodItem", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodItemStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("FoodItemStatus", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BillAmount")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

                    b.Property<Guid?>("CashierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CashierNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ChefId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DiningTableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Tax")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WaiterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CashierId");

                    b.HasIndex("ChefId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("DiningTableId");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("WaiterId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.OrderDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FoodItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasPrecision(17, 2)
                        .HasColumnType("decimal(17,2)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("OrderStatus", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Privilege", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Privilege", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.RolePrivilege", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrivilegeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PrivilegeId");

                    b.HasIndex("PrivilegeId");

                    b.ToTable("RolePrivilege", (string)null);
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.AppUserRole", b =>
                {
                    b.HasOne("EasyResto.Domain.Entities.AppUser", "AppUser")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyResto.Domain.Entities.Role", "Role")
                        .WithMany("AppUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodItem", b =>
                {
                    b.HasOne("EasyResto.Domain.Entities.FoodCategory", "FoodCategory")
                        .WithMany("FoodItems")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyResto.Domain.Entities.FoodItemStatus", "FoodItemStatus")
                        .WithMany("FoodItems")
                        .HasForeignKey("FoodItemStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FoodCategory");

                    b.Navigation("FoodItemStatus");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Order", b =>
                {
                    b.HasOne("EasyResto.Domain.Entities.AppUser", "Cashier")
                        .WithMany("CashierOrders")
                        .HasForeignKey("CashierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyResto.Domain.Entities.AppUser", "Chef")
                        .WithMany("ChefOrders")
                        .HasForeignKey("ChefId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EasyResto.Domain.Entities.DiningTable", "DiningTable")
                        .WithMany("Orders")
                        .HasForeignKey("DiningTableId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyResto.Domain.Entities.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyResto.Domain.Entities.AppUser", "Waiter")
                        .WithMany("WaiterOrders")
                        .HasForeignKey("WaiterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cashier");

                    b.Navigation("Chef");

                    b.Navigation("DiningTable");

                    b.Navigation("OrderStatus");

                    b.Navigation("Waiter");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.OrderDetail", b =>
                {
                    b.HasOne("EasyResto.Domain.Entities.FoodItem", "FoodItem")
                        .WithMany("OrderDetails")
                        .HasForeignKey("FoodItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyResto.Domain.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.RolePrivilege", b =>
                {
                    b.HasOne("EasyResto.Domain.Entities.Privilege", "Privilege")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("PrivilegeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyResto.Domain.Entities.Role", "Role")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Privilege");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.AppUser", b =>
                {
                    b.Navigation("AppUserRoles");

                    b.Navigation("CashierOrders");

                    b.Navigation("ChefOrders");

                    b.Navigation("WaiterOrders");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.DiningTable", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodCategory", b =>
                {
                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodItem", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.FoodItemStatus", b =>
                {
                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Privilege", b =>
                {
                    b.Navigation("RolePrivileges");
                });

            modelBuilder.Entity("EasyResto.Domain.Entities.Role", b =>
                {
                    b.Navigation("AppUserRoles");

                    b.Navigation("RolePrivileges");
                });
#pragma warning restore 612, 618
        }
    }
}
