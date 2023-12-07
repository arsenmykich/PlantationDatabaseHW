﻿// <auto-generated />
using System;
using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HempPlantationsDatabase.Migrations
{
    [DbContext(typeof(PlantationContext))]
    partial class PlantationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("databaseHempPlantations.Models.Agronomist", b =>
                {
                    b.Property<int>("AgronomistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("AgronomistID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AgronomistID");

                    b.ToTable("Agronomists");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Consumer", b =>
                {
                    b.Property<int>("ConsumerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("ConsumerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ConsumerID");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Harvest", b =>
                {
                    b.Property<int>("HarvestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("HarvestID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("VarietyID")
                        .HasColumnType("integer");

                    b.HasKey("HarvestID");

                    b.ToTable("Harvests");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.HarvestProduct", b =>
                {
                    b.Property<int>("HarvestProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("HarvestProductID"));

                    b.Property<int>("HarvestID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("HarvestProductID");

                    b.ToTable("HarvestProducts");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.HempVariety", b =>
                {
                    b.Property<int>("VarietyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("VarietyID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VarietyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VarietyID");

                    b.ToTable("HempVarieties");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("ProductID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("PurchaseID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumerID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("PurchaseID");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Return", b =>
                {
                    b.Property<int>("ReturnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("ReturnID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumerID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReturnID");

                    b.ToTable("Returns");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("ReviewID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ConsumerID")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ReviewID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Tasting", b =>
                {
                    b.Property<int>("TastingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("TastingID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumerID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TastingDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TastingID");

                    b.ToTable("Tastings");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.TastingReview", b =>
                {
                    b.Property<int>("TastingReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("TastingReviewID"));

                    b.Property<int>("ReviewID")
                        .HasColumnType("integer");

                    b.Property<int>("TastingID")
                        .HasColumnType("integer");

                    b.HasKey("TastingReviewID");

                    b.ToTable("TastingReviews");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.TravelAssignment", b =>
                {
                    b.Property<int>("TravelAssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("TravelAssignmentID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<int>("TripID")
                        .HasColumnType("integer");

                    b.HasKey("TravelAssignmentID");

                    b.ToTable("TravelAssignments");
                });

            modelBuilder.Entity("databaseHempPlantations.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("TripID"));

                    b.Property<int>("AgronomistID")
                        .HasColumnType("integer");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("HarvestID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TripDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TripID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity<Harvest>(b =>
            {
                b.HasOne<HempVariety>(h => h.HempVariety)
                    .WithMany()
                    .HasForeignKey(h => h.VarietyID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TravelAssignment>(b =>
            {
                b.HasOne<Trip>(h => h.Trip)
                    .WithMany()
                    .HasForeignKey(h => h.TripID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Trip>(b =>
            {
                b.HasOne<Harvest>(h => h.Harvest)
                    .WithMany()
                    .HasForeignKey(h => h.HarvestID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TastingReview>(b =>
            {
                b.HasOne<Review>(h => h.Review)
                    .WithMany()
                    .HasForeignKey(h => h.ReviewID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Tasting>(h => h.Tasting)
                    .WithMany()
                    .HasForeignKey(h => h.TastingID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Review>(b =>
            {
                b.HasOne<Consumer>(h => h.Consumer)
                    .WithMany()
                    .HasForeignKey(h => h.ConsumerID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Tasting>(b =>
            {
                b.HasOne<Consumer>(h => h.Consumer)
                    .WithMany()
                    .HasForeignKey(h => h.ConsumerID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Product>(h => h.Product)
                    .WithMany()
                    .HasForeignKey(h => h.ProductID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<HarvestProduct>(b =>
            {
                b.HasOne<Harvest>(h => h.Harvest)
                    .WithMany()
                    .HasForeignKey(h => h.HarvestID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Product>(h => h.Product)
                    .WithMany()
                    .HasForeignKey(h => h.ProductID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Return>(b =>
            {
                b.HasOne<Consumer>(h => h.Consumer)
                    .WithMany()
                    .HasForeignKey(h => h.ConsumerID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Product>(h => h.Product)
                    .WithMany()
                    .HasForeignKey(h => h.ProductID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Purchase>(b =>
            {
                b.HasOne<Consumer>(h => h.Consumer)
                    .WithMany()
                    .HasForeignKey(h => h.ConsumerID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Agronomist>(h => h.Agronomist)
                    .WithMany()
                    .HasForeignKey(h => h.AgronomistID)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne<Product>(h => h.Product)
                    .WithMany()
                    .HasForeignKey(h => h.ProductID)
                    .OnDelete(DeleteBehavior.Cascade);
            });


#pragma warning restore 612, 618
        }
    }
}
