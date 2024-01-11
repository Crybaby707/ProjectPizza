﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaCalculator.Infrastructure.Persistence;

#nullable disable

namespace PizzaCalculator.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    partial class PizzaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaCalculator.Domain.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("PizzaSizeId");

                    b.ToTable("PizzaOrders");
                });

            modelBuilder.Entity("PizzaCalculator.Domain.PizzaOrderTopping", b =>
                {
                    b.Property<int>("PizzaOrderToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaOrderToppingID"));

                    b.Property<int>("PizzaOrderId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.HasKey("PizzaOrderToppingID");

                    b.HasIndex("PizzaOrderId");

                    b.HasIndex("ToppingId");

                    b.ToTable("PizzaOrderToppings");
                });

            modelBuilder.Entity("PizzaCalculator.Domain.PizzaSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PizzaSizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 8m,
                            SizeName = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 10m,
                            SizeName = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Cost = 12m,
                            SizeName = "Large"
                        });
                });

            modelBuilder.Entity("PizzaCalculator.Domain.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaCalculator.Domain.PizzaOrder", b =>
                {
                    b.HasOne("PizzaCalculator.Domain.PizzaSize", "PizzaSize")
                        .WithMany()
                        .HasForeignKey("PizzaSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaSize");
                });

            modelBuilder.Entity("PizzaCalculator.Domain.PizzaOrderTopping", b =>
                {
                    b.HasOne("PizzaCalculator.Domain.PizzaOrder", "PizzaOrder")
                        .WithMany("PizzaOrderToppings")
                        .HasForeignKey("PizzaOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaCalculator.Domain.Topping", "Topping")
                        .WithMany("PizzaOrderToppings")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaOrder");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaCalculator.Domain.PizzaOrder", b =>
                {
                    b.Navigation("PizzaOrderToppings");
                });

            modelBuilder.Entity("PizzaCalculator.Domain.Topping", b =>
                {
                    b.Navigation("PizzaOrderToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
