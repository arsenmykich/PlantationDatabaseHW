﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HempPlantationsDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agronomists",
                columns: table => new
                {
                    AgronomistID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Specialty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agronomists", x => x.AgronomistID);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    ConsumerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.ConsumerID);
                });

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    HarvestID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    VarietyID = table.Column<int>(type: "integer", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.HarvestID);
                    table.ForeignKey(
                        name: "FK_Harvests_VarietyID",
                        column: x => x.VarietyID,
                        principalTable: "HempVarieties",
                        principalColumn: "VarietyID");
                    table.ForeignKey(
                        name: "FK_Harvests_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                });

            migrationBuilder.CreateTable(
                name: "HarvestProducts",
                columns: table => new
                {
                    HarvestProductID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HarvestID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestProducts", x => x.HarvestProductID);
                    table.ForeignKey(
                        name: "FK_HarvestProducts_HarvestID",
                        column: x => x.HarvestID,
                        principalTable: "Harvests",
                        principalColumn: "HarvestID");
                    table.ForeignKey(
                        name: "FK_HarvestProducts_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "HempVarieties",
                columns: table => new
                {
                    VarietyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    VarietyName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HempVarieties", x => x.VarietyID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConsumerID = table.Column<int>(type: "integer", nullable: false),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseID);
                    table.ForeignKey(
                        name: "FK_Purchases_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                    table.ForeignKey(
                        name: "FK_Purchases_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Purchases_ConsumerID",
                        column: x => x.ConsumerID,
                        principalTable: "Consumers",
                        principalColumn: "ConsumerID");
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    ReturnID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConsumerID = table.Column<int>(type: "integer", nullable: false),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.ReturnID);
                    table.ForeignKey(
                        name: "FK_Returns_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                    table.ForeignKey(
                        name: "FK_Returns_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Returns_ConsumerID",
                        column: x => x.ConsumerID,
                        principalTable: "Consumers",
                        principalColumn: "ConsumerID");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConsumerID = table.Column<int>(type: "integer", nullable: false),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                    table.ForeignKey(
                        name: "FK_Reviews_ConsumerID",
                        column: x => x.ConsumerID,
                        principalTable: "Consumers",
                        principalColumn: "ConsumerID");
                });

            migrationBuilder.CreateTable(
                name: "TastingReviews",
                columns: table => new
                {
                    TastingReviewID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TastingID = table.Column<int>(type: "integer", nullable: false),
                    ReviewID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TastingReviews", x => x.TastingReviewID);
                    table.ForeignKey(
                        name: "FK_TastingReviews_TastingID",
                        column: x => x.TastingID,
                        principalTable: "Tastings",
                        principalColumn: "TastingID");
                    table.ForeignKey(
                        name: "FK_TastingReviews_ReviewsID",
                        column: x => x.ReviewID,
                        principalTable: "Reviews",
                        principalColumn: "ReviewsID");
                });

            migrationBuilder.CreateTable(
                name: "Tastings",
                columns: table => new
                {
                    TastingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    ConsumerID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    TastingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tastings", x => x.TastingID);
                    table.ForeignKey(
                        name: "FK_Tastings_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                    table.ForeignKey(
                        name: "FK_Tastings_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Tastings_ConsumerID",
                        column: x => x.ConsumerID,
                        principalTable: "Consumers",
                        principalColumn: "ConsumerID");
                });

            migrationBuilder.CreateTable(
                name: "TravelAssignments",
                columns: table => new
                {
                    TravelAssignmentID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    TripID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAssignments", x => x.TravelAssignmentID);
                    table.ForeignKey(
                        name: "FK_TravelAssignments_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "TripID");
                    table.ForeignKey(
                        name: "FK_TravelAssignments_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AgronomistID = table.Column<int>(type: "integer", nullable: false),
                    HarvestID = table.Column<int>(type: "integer", nullable: false),
                    TripDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Destination = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_Trips_AgronomistID",
                        column: x => x.AgronomistID,
                        principalTable: "Agronomists",
                        principalColumn: "AgronomistID");
                    table.ForeignKey(
                        name: "FK_Trips_HarvetsID",
                        column: x => x.HarvestID,
                        principalTable: "Harvests",
                        principalColumn: "HarvestID");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agronomists");

            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "HarvestProducts");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "HempVarieties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "TastingReviews");

            migrationBuilder.DropTable(
                name: "Tastings");

            migrationBuilder.DropTable(
                name: "TravelAssignments");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
