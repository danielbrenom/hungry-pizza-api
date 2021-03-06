﻿// <auto-generated />

using HungryPizzaAPI.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HungryPizzaAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    internal class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HungryPizzaAPI.Domain.Models.Tables.Customer", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Address")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CEP")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("CPF")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Customers");
            });

            modelBuilder.Entity("HungryPizzaAPI.Domain.Models.Tables.Tastes", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                        SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.Property<float>("Price")
                    .HasColumnType("real");

                b.HasKey("Id");

                b.ToTable("Tastes");

                b.HasData(
                    new
                    {
                        Id = 1,
                        Name = "3 Queijos",
                        Price = 50f
                    },
                    new
                    {
                        Id = 2,
                        Name = "Frango com requeijão",
                        Price = 59.99f
                    },
                    new
                    {
                        Id = 3,
                        Name = "Mussarela",
                        Price = 42.5f
                    },
                    new
                    {
                        Id = 4,
                        Name = "Calabresa",
                        Price = 42.5f
                    },
                    new
                    {
                        Id = 5,
                        Name = "Pepperoni",
                        Price = 55f
                    },
                    new
                    {
                        Id = 6,
                        Name = "Portuguesa",
                        Price = 45f
                    },
                    new
                    {
                        Id = 7,
                        Name = "Veggie",
                        Price = 59.99f
                    });
            });
#pragma warning restore 612, 618
        }
    }
}