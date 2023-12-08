using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace HempPlantationsDatabase.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly PlantationContext context;

        public HomeController(PlantationContext context)
        {
            this.context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}




        public IActionResult CreateHarvest()
        {
            // Implement your logic for creating a new harvest
            return View(); // You can redirect to the Create view for Harvests or implement your logic
        }


        public IActionResult InputDataDistinctCustomers()
        {
            return View();
        }
        //1
        public IActionResult ShowDistinctConsumers(int agronomID, int n ,DateTime from_date, DateTime to_date)
        {
            var distinctCustomerIds = context.Purchases
                .Where(p => p.AgronomistID == agronomID && p.PurchaseDate >= from_date && p.PurchaseDate <= to_date)
                .GroupBy(p => p.ConsumerID)
                .Where(g => g.Count() >= n)
                .Select(g => g.Key)
                .ToList();

            return View(distinctCustomerIds.ToList());
        }

        ////2
        //public IActionResult ProductsPurchasedByConsumerC(int consumerId)
        //{
        //    var products = context.Purchases
        //        .Where(p => p.ConsumerID == consumerId)
        //        .Include(p => p.Product)
        //        .Select(p => p.Product)
        //        .ToList();

        //    ViewData["ConsumerId"] = consumerId; // Pass consumerId to the view for display
        //    return View(products);
        //}
        //2 upd
        public IActionResult ShowProductsPurchasedByConsumer(int consumerID, DateTime from_date_products, DateTime to_date_products)
        {
            var purchasedProductIds = context.Purchases
                .Where(p => p.ConsumerID == consumerID && p.PurchaseDate >= from_date_products && p.PurchaseDate <= to_date_products)
                .Select(p => p.ProductID)
                .ToList();

            return View(purchasedProductIds);
        }


        //3 upd
        public IActionResult ShowAgronomistsForConsumer(int consumerID_tastings, DateTime from_date_tastings, DateTime to_date_tastings, int n_tastings)
        {
            var agronomistIds = context.Tastings
                .Where(t => t.ConsumerID == consumerID_tastings && t.TastingDate >= from_date_tastings && t.TastingDate <= to_date_tastings)
                .GroupBy(t => t.AgronomistID)
                .Where(g => g.Count() >= n_tastings)
                .Select(g => g.Key)
                .ToList();

            return View(agronomistIds);
        }



        //4 upd
        public IActionResult ShowAgronomistsTraveledWithA(int agronomID_travel, DateTime from_date_travel, DateTime to_date_travel)
        {
            var traveledAgronomistIds = context.Trips
                .Where(t => t.AgronomistID == agronomID_travel && t.TripDate >= from_date_travel && t.TripDate <= to_date_travel)
                .Select(t => t.AgronomistID)
                .Distinct()
                .ToList();

            return View(traveledAgronomistIds);
        }


        //5
        public IActionResult ShowAgronomistsForConsumerSalesAndTastings(int consumerID_sales_tastings, DateTime from_date_sales_tastings, DateTime to_date_sales_tastings)
        {
            var agronomistIds = context.Tastings
                .Where(t => t.ConsumerID == consumerID_sales_tastings && t.TastingDate >= from_date_sales_tastings && t.TastingDate <= to_date_sales_tastings
                    && context.Purchases.Any(p => p.ConsumerID == consumerID_sales_tastings && p.AgronomistID == t.AgronomistID && p.PurchaseDate >= from_date_sales_tastings && p.PurchaseDate <= to_date_sales_tastings))
                .Select(t => t.AgronomistID)
                .Distinct()
                .ToList();

            return View(agronomistIds);
        }



        //6 need fix upd needs check
        public IActionResult ShowConsumersForDistinctProductPurchases(int n_distinct_products, DateTime from_date_distinct_products, DateTime to_date_distinct_products)
        {
            var consumerIds = context.Purchases
                .Where(p => p.PurchaseDate >= from_date_distinct_products && p.PurchaseDate <= to_date_distinct_products)
                .GroupBy(p => p.ConsumerID)
                .Where(g => g.Select(p => p.ProductID).Distinct().Count() >= n_distinct_products)
                .Select(g => g.Key)
                .ToList();

            return View(consumerIds);
        }




        //7 upd
        public IActionResult ShowAgronomistsForDistinctHempVarieties(int n_distinct_hemp_varieties, DateTime from_date_distinct_hemp_varieties, DateTime to_date_distinct_hemp_varieties)
        {
            var agronomistIds = context.Harvests
                .Where(h => h.HarvestDate >= from_date_distinct_hemp_varieties && h.HarvestDate <= to_date_distinct_hemp_varieties)
                .GroupBy(h => h.AgronomistID)
                .Where(g => g.Select(h => h.VarietyID).Distinct().Count() >= n_distinct_hemp_varieties)
                .Select(g => g.Key)
                .ToList();

            return View(agronomistIds);
        }

        //8 upd
        public IActionResult ShowSharedTastings(int consumer_id_shared_tastings, int agronomist_id_shared_tastings, DateTime from_date_shared_tastings, DateTime to_date_shared_tastings)
        {
            var sharedTastingIds = context.Tastings
                .Where(t => t.ConsumerID == consumer_id_shared_tastings && t.AgronomistID == agronomist_id_shared_tastings && t.TastingDate >= from_date_shared_tastings && t.TastingDate <= to_date_shared_tastings)
                .Select(t => t.TastingID)
                .Distinct()
                .ToList();

            return View(sharedTastingIds);
        }

        //9 upd
        public IActionResult ShowTastingCounts(int agronom_id_tasting_counts, DateTime from_date_tasting_counts, DateTime to_date_tasting_counts, int min_consumers_tasting_counts)
        {
            var tastingCounts = context.Tastings
                .Where(t => t.AgronomistID == agronom_id_tasting_counts && t.TastingDate >= from_date_tasting_counts && t.TastingDate <= to_date_tasting_counts)
                .GroupBy(t => new { t.AgronomistID, t.ProductID })
                .Where(g => g.Count() >= min_consumers_tasting_counts)
                .Select(g => new { AgronomID = g.Key.AgronomistID, ProductID = g.Key.ProductID, TastingCount = g.Count() })
                .ToList();

            return View(tastingCounts);
        }

        //10 upd
        public IActionResult ShowReviewCounts(int consumer_id_review_counts, DateTime from_date_review_counts, DateTime to_date_review_counts)
        {
            var reviewCounts = context.Reviews
                .Where(r => r.ConsumerID == consumer_id_review_counts && r.ReviewDate >= from_date_review_counts && r.ReviewDate <= to_date_review_counts)
                .GroupBy(r => new { ReviewMonth = r.ReviewDate.Month })
                .Select(g => new ReviewCountViewModel { ReviewMonth = g.Key.ReviewMonth, ReviewCount = g.Count() })
                .ToList();

            return View(reviewCounts);
        }



        //11 need fix(extremely)
        //public IActionResult ShowSortedHempSorts(int n, DateTime fromDate, DateTime toDate)
        //{
        //    var sortedHempSorts = context.Harvests
        //        .Where(h => h.HarvestDate >= fromDate && h.HarvestDate <= toDate)
        //        .GroupBy(h => h.VarietyID)
        //        .Select(group => new
        //        {
        //            HempSort = group.Key,
        //            AvgTravelCount = context.Agronomists
        //                .Where(a => a.TravelAssignments
        //                    .Any(ta => ta.TravelDate >= fromDate && ta.TravelDate <= toDate)
        //                    && context.Harvests
        //                        .Count(h => h.AgronomistID == a.AgronomistID && h.HarvestDate >= fromDate && h.HarvestDate <= toDate) >= n
        //                )
        //                .Select(a => a.TravelAssignments.Count(ta => ta.TravelDate >= fromDate && ta.TravelDate <= toDate))
        //                .DefaultIfEmpty(0)
        //                .Average()
        //        })
        //        .OrderByDescending(result => result.AvgTravelCount)
        //        .ToList();

        //    return View(sortedHempSorts);
        //}

        //12 not upd
        public IActionResult ShowProductsByReturnPercentage(int n)
        {
            var products = context.Purchases
                .GroupBy(p => p.ProductID)
                .Select(g => new ProductPurchaseViewModel
                {
                    ProductID = g.Key,
                    CustomerCount = g.Select(p => p.ConsumerID).Distinct().Count(),
                    ReturnCustomerCount = context.Returns
                        .Count(r => r.ProductID == g.Key && r.Quantity > 0),
                    ReturnPercentage = g.Any() ?
                        context.Returns.Count(r => r.ProductID == g.Key && r.Quantity > 0) * 100.0 / g.Select(p => p.ConsumerID).Distinct().Count() : 0
                })
                .Where(p => p.CustomerCount >= n)
                .OrderByDescending(p => p.ReturnPercentage)
                .ToList();

            return View(products);
        }

















        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Schema()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
