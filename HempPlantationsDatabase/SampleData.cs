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
                    AgronomistID = 10,
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
                FirstName = "Andrian",
                LastName = "Maystrenko",
                Email = "asd@gmail.com",
                PhoneNumber = "239045834",
                HireDate = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                Specialty = "none2"
            });
            // Add data to Consumers table
            context.Consumers.AddRange();
            //    new Consumer
            //    {
            //        FirstName = "John",
            //        LastName = "Doe",
            //        Email = "john.doe@example.com",
            //        PhoneNumber = "1234567890",
            //        RegistrationDate = DateTime.UtcNow
            //    },
            //    new Consumer
            //    {
            //        FirstName = "Jane",
            //        LastName = "Smith",
            //        Email = "jane.smith@example.com",
            //        PhoneNumber = "9876543210",
            //        RegistrationDate = DateTime.UtcNow
            //    });

            //// Add data to HempVarieties table
            //context.HempVarieties.AddRange(
            //    new HempVariety
            //    {
            //        VarietyName = "Variety1",
            //        Description = "Description for Variety1"
            //    },
            //    new HempVariety
            //    {
            //        VarietyName = "Variety2",
            //        Description = "Description for Variety2"
            //    });

            //// Add data to Products table
            //context.Products.AddRange(
            //    new Product
            //    {
            //        ProductName = "Product1",
            //        Price = 1099,
            //        Description = "Description for Product1"
            //    },
            //    new Product
            //    {
            //        ProductName = "Product2",
            //        Price = 1999,
            //        Description = "Description for Product2"
            //    });

            //// Add data to Harvests table
            //context.Harvests.AddRange(
            //    new Harvest
            //    {
            //        HarvestID = 1,
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        VarietyID = 1,    // Use the VarietyID from HempVarieties table
            //        HarvestDate = DateTime.UtcNow,
            //        Quantity = 100
            //    },
            //    new Harvest
            //    {
            //        HarvestID = 2,
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        VarietyID = 2,    // Use the VarietyID from HempVarieties table
            //        HarvestDate = DateTime.UtcNow,
            //        Quantity = 150
            //    });

            //// Add data to Tastings table
            //context.Tastings.AddRange(
            //    new Tasting
            //    {
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        ConsumerID = 1,   // Use the ConsumerID from Consumers table
            //        ProductID = 1,    // Use the ProductID from Products table
            //        TastingDate = DateTime.UtcNow,
            //        Rating = 4
            //    },
            //    new Tasting
            //    {
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        ConsumerID = 2,   // Use the ConsumerID from Consumers table
            //        ProductID = 2,    // Use the ProductID from Products table
            //        TastingDate = DateTime.UtcNow,
            //        Rating = 5
            //    });

            //// Add data to Purchases table
            //context.Purchases.AddRange(
            //    new Purchase
            //    {
            //        ConsumerID = 1,   // Use the ConsumerID from Consumers table
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        ProductID = 1,    // Use the ProductID from Products table
            //        PurchaseDate = DateTime.UtcNow,
            //        Quantity = 2,
            //        TotalPrice = 2198
            //    },
            //    new Purchase
            //    {
            //        ConsumerID = 2,   // Use the ConsumerID from Consumers table
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        ProductID = 2,    // Use the ProductID from Products table
            //        PurchaseDate = DateTime.UtcNow,
            //        Quantity = 3,
            //        TotalPrice = 5997
            //    });

            //// Add data to Returns table
            //context.Returns.AddRange(
            //    new Return
            //    {
            //        ConsumerID = 1,   // Use the ConsumerID from Consumers table
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        ProductID = 1,    // Use the ProductID from Products table
            //        ReturnDate = DateTime.UtcNow,
            //        Quantity = 1
            //    },
            //    new Return
            //    {
            //        ConsumerID = 2,   // Use the ConsumerID from Consumers table
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        ProductID = 2,    // Use the ProductID from Products table
            //        ReturnDate = DateTime.UtcNow,
            //        Quantity = 2
            //    });

            //// Add data to Trips table
            //context.Trips.AddRange(
            //    new Trip
            //    {
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        HarvestID = 1,    // Use the HarvestID from Harvests table
            //        TripDate = DateTime.UtcNow,
            //        Destination = "Destination1"
            //    },
            //    new Trip
            //    {
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        HarvestID = 2,    // Use the HarvestID from Harvests table
            //        TripDate = DateTime.UtcNow,
            //        Destination = "Destination2"
            //    });

            //// Add data to Reviews table
            //context.Reviews.AddRange(
            //    new Review
            //    {
            //        ConsumerID = 1,   // Use the ConsumerID from Consumers table
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        ReviewDate = DateTime.UtcNow,
            //        Rating = 4,
            //        Comment = "Good experience"
            //    },
            //    new Review
            //    {
            //        ConsumerID = 2,   // Use the ConsumerID from Consumers table
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        ReviewDate = DateTime.UtcNow,
            //        Rating = 5,
            //        Comment = "Excellent service"
            //    });

            //// Add data to HarvestProducts table
            //context.HarvestProducts.AddRange(
            //    new HarvestProduct
            //    {
            //        HarvestID = 1, // Use the HarvestID from Harvests table
            //        ProductID = 1, // Use the ProductID from Products table
            //        Quantity = 80
            //    },
            //    new HarvestProduct
            //    {
            //        HarvestID = 2, // Use the HarvestID from Harvests table
            //        ProductID = 2, // Use the ProductID from Products table
            //        Quantity = 120
            //    });

            //// Add data to TastingReviews table
            //context.TastingReviews.AddRange(
            //    new TastingReview
            //    {
            //        TastingID = 1, // Use the TastingID from Tastings table
            //        ReviewID = 1   // Use the ReviewID from Reviews table
            //    },
            //    new TastingReview
            //    {
            //        TastingID = 2, // Use the TastingID from Tastings table
            //        ReviewID = 2   // Use the ReviewID from Reviews table
            //    });

            //// Add data to TravelAssignments table
            //context.TravelAssignments.AddRange(
            //    new TravelAssignment
            //    {
            //        AgronomistID = 1, // Use the AgronomistID from Agronomists table
            //        TripID = 1        // Use the TripID from Trips table
            //    },
            //    new TravelAssignment
            //    {
            //        AgronomistID = 2, // Use the AgronomistID from Agronomists table
            //        TripID = 2        // Use the TripID from Trips table
            //    });

            //context.SaveChanges();

        }
    }
}
