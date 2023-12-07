using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;

namespace HempPlantationsDatabase
{
    public static class SampleData
    {
        public static void Initialize(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<PlantationContext>();
            context.Database.EnsureCreated();
            AddPlantations(context);
        }
        private static void AddPlantations(PlantationContext context)
        {
            context.Agronomists.AddRange(
                new Agronomist
                {
                    AgronomistID = 1,
                    FirstName = "Arsen",
                    LastName = "Mykich",
                    Email = "qwe@gmail.com",
                    PhoneNumber = "23465345756",
                    HireDate = new DateTime(2000, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "none1"
                },
                new Agronomist
                {
                    AgronomistID = 2,
                    FirstName = "Anna",
                    LastName = "Smith",
                    Email = "anna.smith@gmail.com",
                    PhoneNumber = "9876543210",
                    HireDate = new DateTime(2005, 5, 10, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "agriculture"
                },
                new Agronomist
                {
                    AgronomistID = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    HireDate = new DateTime(2010, 9, 15, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "horticulture"
                },
                new Agronomist
                {
                    AgronomistID = 4,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Email = "emily.johnson@example.com",
                    PhoneNumber = "5551234567",
                    HireDate = new DateTime(2007, 7, 20, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "none2"
                },
                new Agronomist
                {
                    AgronomistID = 5,
                    FirstName = "Michael",
                    LastName = "Brown",
                    Email = "michael.brown@example.com",
                    PhoneNumber = "3337779999",
                    HireDate = new DateTime(2012, 3, 5, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "organic farming"
                },
                new Agronomist
                {
                    AgronomistID = 6,
                    FirstName = "Sophia",
                    LastName = "Martinez",
                    Email = "sophia.martinez@example.com",
                    PhoneNumber = "7778889999",
                    HireDate = new DateTime(2015, 8, 12, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "botany"
                },
                new Agronomist
                {
                    AgronomistID = 7,
                    FirstName = "Daniel",
                    LastName = "Garcia",
                    Email = "daniel.garcia@example.com",
                    PhoneNumber = "1110002222",
                    HireDate = new DateTime(2018, 12, 1, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "agroecology"
                },
                new Agronomist
                {
                    AgronomistID = 8,
                    FirstName = "Arsen",
                    LastName = "Mykichee",
                    Email = "qwe@gmail.com",
                    PhoneNumber = "23465345756",
                    HireDate = new DateTime(2000, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "none1"
                },
                new Agronomist
                {
                    AgronomistID = 9,
                    FirstName = "Arsen",
                    LastName = "Mykichww",
                    Email = "qwe@gmail.com",
                    PhoneNumber = "23465345756",
                    HireDate = new DateTime(2000, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "none1"
                },
                new Agronomist
                {
                    AgronomistID = 10,
                    FirstName = "Arsen",
                    LastName = "Mykichaa",
                    Email = "qwe@gmail.com",
                    PhoneNumber = "23465345756",
                    HireDate = new DateTime(2000, 2, 1, 0, 0, 0, DateTimeKind.Utc),
                    Specialty = "none1"
                });

            context.Consumers.AddRange(
                new Consumer
                {
                    ConsumerID = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "1234567890",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 2,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice.smith@example.com",
                    PhoneNumber = "9876543210",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 3,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Email = "emily.johnson@example.com",
                    PhoneNumber = "5551234567",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 4,
                    FirstName = "Michael",
                    LastName = "Brown",
                    Email = "michael.brown@example.com",
                    PhoneNumber = "3337779999",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 5,
                    FirstName = "David",
                    LastName = "Anderson",
                    Email = "david.anderson@example.com",
                    PhoneNumber = "4445556666",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 6,
                    FirstName = "Olivia",
                    LastName = "Martinez",
                    Email = "olivia.martinez@example.com",
                    PhoneNumber = "7778889999",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 7,
                    FirstName = "Ethan",
                    LastName = "Garcia",
                    Email = "ethan.garcia@example.com",
                    PhoneNumber = "1110002222",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 8,
                    FirstName = "Sophia",
                    LastName = "Lopez",
                    Email = "sophia.lopez@example.com",
                    PhoneNumber = "8887776666",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 9,
                    FirstName = "Noah",
                    LastName = "Hernandez",
                    Email = "noah.hernandez@example.com",
                    PhoneNumber = "9998887777",
                    RegistrationDate = DateTime.UtcNow
                },
                new Consumer
                {
                    ConsumerID = 10,
                    FirstName = "Noaah",
                    LastName = "Hernansddez",
                    Email = "noah.h33ernandez@example.com",
                    PhoneNumber = "99988817777",
                    RegistrationDate = DateTime.UtcNow
                });


            // Add data to HempVarieties table
            context.HempVarieties.AddRange(
                new HempVariety
                {
                    VarietyID = 1,
                    VarietyName = "Variety1",
                    Description = "Description for Variety1"
                },
                new HempVariety
                {
                    VarietyID = 2,
                    VarietyName = "Variety2",
                    Description = "Description for Variety2"
                },
                new HempVariety
                {
                    VarietyID = 3,
                    VarietyName = "Variety3",
                    Description = "Description for Variety3"
                },
                new HempVariety
                {
                    VarietyID = 4,
                    VarietyName = "Variety4",
                    Description = "Description for Variety4"
                },
                new HempVariety
                {
                    VarietyID = 5,
                    VarietyName = "Variety5",
                    Description = "Description for Variety5"
                },
                new HempVariety
                {
                    VarietyID = 6,
                    VarietyName = "Variety6",
                    Description = "Description for Variety6"
                },
                new HempVariety
                {
                    VarietyID = 7,
                    VarietyName = "Variety7",
                    Description = "Description for Variety7"
                },
                new HempVariety
                {
                    VarietyID = 8,
                    VarietyName = "Variety8",
                    Description = "Description for Variety8"
                },
                new HempVariety
                {
                    VarietyID = 9,
                    VarietyName = "Variety9",
                    Description = "Description for Variety9"
                },
                new HempVariety
                {
                    VarietyID = 10,
                    VarietyName = "Variety10",
                    Description = "Description for Variety10"
                });

            // Add data to Products table
            context.Products.AddRange(
                new Product
                {
                    ProductID = 1,
                    ProductName = "Product1",
                    Price = 1099,
                    Description = "Description for Product1"
                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Product2",
                    Price = 1999,
                    Description = "Description for Product2"
                },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Product3",
                    Price = 2999,
                    Description = "Description for Product3"
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Product4",
                    Price = 1499,
                    Description = "Description for Product4"
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "Product5",
                    Price = 2499,
                    Description = "Description for Product5"
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "Product6",
                    Price = 1699,
                    Description = "Description for Product6"
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "Product7",
                    Price = 3999,
                    Description = "Description for Product7"
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "Product8",
                    Price = 799,
                    Description = "Description for Product8"
                },
                new Product
                {
                    ProductID = 9,
                    ProductName = "Product9",
                    Price = 299,
                    Description = "Description for Product9"
                },
                new Product
                {

                    ProductID = 10,
                    ProductName = "Product10",
                    Price = 4999,
                    Description = "Description for Product10"
                });

            // Add data to Harvests table
            context.Harvests.AddRange(
                new Harvest
                {
                    HarvestID = 1,
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    VarietyID = 1,    // Use the VarietyID from HempVarieties table
                    HarvestDate = DateTime.UtcNow,
                    Quantity = 100
                },
                new Harvest
                {
                    HarvestID = 2,
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    VarietyID = 2,    // Use the VarietyID from HempVarieties table
                    HarvestDate = DateTime.UtcNow,
                    Quantity = 150
                });

            // Add data to Tastings table
            context.Tastings.AddRange(
                new Tasting
                {
                    TastingID = 1,
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    ConsumerID = 1,   // Use the ConsumerID from Consumers table
                    ProductID = 1,    // Use the ProductID from Products table
                    TastingDate = DateTime.UtcNow,
                    Rating = 4
                },
                new Tasting
                {
                    TastingID = 2,
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    ConsumerID = 2,   // Use the ConsumerID from Consumers table
                    ProductID = 2,    // Use the ProductID from Products table
                    TastingDate = DateTime.UtcNow,
                    Rating = 5
                });

            // Add data to Purchases table
            context.Purchases.AddRange(
                new Purchase
                {
                    PurchaseID = 1,
                    ConsumerID = 1,   // Use the ConsumerID from Consumers table
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    ProductID = 1,    // Use the ProductID from Products table
                    PurchaseDate = DateTime.UtcNow,
                    Quantity = 2,
                    TotalPrice = 2198
                },
                new Purchase
                {
                    PurchaseID = 2,
                    ConsumerID = 2,   // Use the ConsumerID from Consumers table
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    ProductID = 2,    // Use the ProductID from Products table
                    PurchaseDate = DateTime.UtcNow,
                    Quantity = 3,
                    TotalPrice = 5997
                });

            // Add data to Returns table
            context.Returns.AddRange(
                new Return
                {
                    ReturnID = 1,
                    ConsumerID = 1,   // Use the ConsumerID from Consumers table
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    ProductID = 1,    // Use the ProductID from Products table
                    ReturnDate = DateTime.UtcNow,
                    Quantity = 1
                },
                new Return
                {
                    ReturnID = 2,
                    ConsumerID = 2,   // Use the ConsumerID from Consumers table
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    ProductID = 2,    // Use the ProductID from Products table
                    ReturnDate = DateTime.UtcNow,
                    Quantity = 2
                });

            // Add data to Trips table
            context.Trips.AddRange(
                new Trip
                {
                    TripID = 1,
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    HarvestID = 1,    // Use the HarvestID from Harvests table
                    TripDate = DateTime.UtcNow,
                    Destination = "Destination1"
                },
                new Trip
                {
                    TripID = 2,
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    HarvestID = 2,    // Use the HarvestID from Harvests table
                    TripDate = DateTime.UtcNow,
                    Destination = "Destination2"
                });

            // Add data to Reviews table
            context.Reviews.AddRange(
                new Review
                {
                    ReviewID = 1,
                    ConsumerID = 1,   // Use the ConsumerID from Consumers table
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    ReviewDate = DateTime.UtcNow,
                    Rating = 4,
                    Comment = "Good experience"
                },
                new Review
                {
                    ReviewID = 2,
                    ConsumerID = 2,   // Use the ConsumerID from Consumers table
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    ReviewDate = DateTime.UtcNow,
                    Rating = 5,
                    Comment = "Excellent service"
                });

            // Add data to HarvestProducts table
            context.HarvestProducts.AddRange(
                new HarvestProduct
                {
                    HarvestProductID = 1,
                    HarvestID = 1, // Use the HarvestID from Harvests table
                    ProductID = 1, // Use the ProductID from Products table
                    Quantity = 80
                },
                new HarvestProduct
                {
                    HarvestProductID = 2,
                    HarvestID = 2, // Use the HarvestID from Harvests table
                    ProductID = 2, // Use the ProductID from Products table
                    Quantity = 120
                });

            // Add data to TastingReviews table
            context.TastingReviews.AddRange(
                new TastingReview
                {
                    TastingReviewID = 1,
                    TastingID = 1, // Use the TastingID from Tastings table
                    ReviewID = 1   // Use the ReviewID from Reviews table
                },
                new TastingReview
                {
                    TastingReviewID = 2,
                    TastingID = 2, // Use the TastingID from Tastings table
                    ReviewID = 2   // Use the ReviewID from Reviews table
                });

            // Add data to TravelAssignments table
            context.TravelAssignments.AddRange(
                new TravelAssignment
                {
                    TravelAssignmentID = 1,
                    AgronomistID = 1, // Use the AgronomistID from Agronomists table
                    TripID = 1        // Use the TripID from Trips table
                },
                new TravelAssignment
                {
                    TravelAssignmentID = 2,
                    AgronomistID = 2, // Use the AgronomistID from Agronomists table
                    TripID = 2        // Use the TripID from Trips table
                });

            context.SaveChanges();
        }
    }
}
