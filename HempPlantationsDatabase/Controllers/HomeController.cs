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
        //2
        public IActionResult ShowProductsPurchasedByConsumer(int consumerID)
        {
            var products = context.Purchases
                .Where(p => p.ConsumerID == consumerID)
                .Select(p => p.ProductID)
                .Distinct()
                .ToList();

            return View(products);
        }

        //3
        public IActionResult ShowAgronomistsForConsumer(int consumerID, int n)
        {
            var agronomists = context.Tastings
                .Where(t => t.ConsumerID == consumerID)
                .GroupBy(t => t.AgronomistID)
                .Where(g => g.Select(t => t.ProductID).Distinct().Count() >= n)
                .Select(g => g.Key)
                .Distinct()
                .ToList();

            return View(agronomists);
        }


        //4
        public IActionResult ShowAgronomistsForTravelAssignments(int agronomID)
        {
            var agronomists = context.TravelAssignments
                .Where(t => t.AgronomistID == agronomID)
                .Select(t => t.AgronomistID)
                .Distinct()
                .ToList();

            return View(agronomists);
        }

        //5
        public IActionResult ShowAgronomistsForConsumer2(int consumerID)
        {
            var agronomists = context.Tastings
                .Where(t => t.ConsumerID == consumerID && context.Purchases.Any(p => p.ConsumerID == consumerID && p.AgronomistID == t.AgronomistID))
                .Select(t => t.AgronomistID)
                .Distinct()
                .ToList();

            return View(agronomists);
        }


        //6 need fix
        public IActionResult ShowConsumersWithDistinctProducts(int n)
        {
            var consumers = context.Purchases
                .GroupBy(p => p.ConsumerID)
                .Where(g => g.Select(p => p.ProductID).Distinct().Count() >= n)
                .Select(g => g.Key)
                .ToList();

            return View(consumers);
        }
        //7
        public IActionResult ShowAgronomistsWithDistinctHempSorts(int n)
        {
            var agronomists = context.Harvests
                .Join(
                    context.Agronomists,
                    h => h.AgronomistID,
                    a => a.AgronomistID,
                    (h, a) => new { Harvest = h, Agronomist = a }
                )
                .GroupBy(x => x.Agronomist.AgronomistID)
                .Where(g => g.Select(x => x.Harvest.VarietyID).Distinct().Count() >= n)
                .Select(g => g.Key)
                .ToList();

            return View(agronomists);
        }
        //8
        public IActionResult ShowCommonTastings(int consumerID, int agronomID)
        {
            var commonTastings = context.Tastings
                .Where(t => t.ConsumerID == consumerID && t.AgronomistID == agronomID)
                .Select(t => t.TastingID)
                .Distinct()
                .ToList();

            return View(commonTastings);
        }
        //9
        public IActionResult ShowTastingCountForAgronomistAndProduct(int agronomID, int n)
        {
            var tastingCounts = context.Tastings
                .Where(t => t.AgronomistID == agronomID)
                .GroupBy(t => new { t.AgronomistID, t.ProductID })
                .Where(g => g.Select(t => t.ConsumerID).Distinct().Count() >= n)
                .Select(g => new
                {
                    AgronomID = g.Key.AgronomistID,
                    ProductID = g.Key.ProductID,
                    TastingCount = g.Select(t => t.ConsumerID).Distinct().Count()
                })
                .ToList();

            return View(tastingCounts);
        }
        //10
        public IActionResult ShowReviewCountByMonth(int customerID)
        {
            var reviewCounts = context.Reviews
                .Where(r => r.ConsumerID == customerID)
                .GroupBy(r => new { ReviewMonth = r.ReviewDate.Month })
                .Select(g => new ReviewCountViewModel
                {
                    ReviewMonth = g.Key.ReviewMonth,
                    ReviewCount = g.Count()
                })
                .ToList();

            return View(reviewCounts);
        }
        //11 need fix
        public IActionResult ShowHempSortsByAvgTravelCount(int n)
        {
            var hempSorts = context.Harvests
                .GroupBy(h => h.VarietyID)
                .Join(
                    context.Agronomists
                        .GroupJoin(
                            context.TravelAssignments,
                            a => a.AgronomistID,
                            ta => ta.AgronomistID,
                            (a, travelAssignments) => new
                            {
                                a.AgronomistID,
                                TravelCount = travelAssignments.DistinctBy(ta => ta.TravelAssignmentID).Count()
                            }
                        )
                        .Where(a => a.TravelCount >= n),
                    h => h.First().AgronomistID,
                    a => a.AgronomistID,
                    (h, a) => new HempSortAvgTravelCountViewModel
                    {
                        HempSort = h.Key,
                        AvgTravelCount = a.TravelCount
                    }
                )
                .OrderByDescending(x => x.AvgTravelCount)
                .ToList();

            return View(hempSorts);
        }
        //12
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
                    ReturnPercentage = context.Returns
                        .Count(r => r.ProductID == g.Key && r.Quantity > 0) * 100.0 / g.Select(p => p.ConsumerID).Distinct().Count()
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
