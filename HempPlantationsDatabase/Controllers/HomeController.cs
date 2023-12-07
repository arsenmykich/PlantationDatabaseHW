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
        public IActionResult ShowDistinctConsumers(int agronomID, int n)
        {
            var distinctCustomers = context.Purchases
                .Where(p => p.AgronomistID == agronomID)
                .GroupBy(p => p.ConsumerID)
                .Where(g => g.Count() >= n)
                .Select(g => g.Key)
                .Distinct();
            //        var distinctCustomerIds = context.Purchases
            //.Where(p => p.AgronomistID == agronomID )
            //.GroupBy(p => p.ConsumerID)
            //.Where(g => g.Count() >= n)
            //.Select(g => g.Key)
            //.ToList();
            //        var consumerDetails = context.Consumers
            //.Where(c => distinctCustomerIds.Contains(c.ConsumerID))
            //.Select(c => new { c.ConsumerID, c.FirstName, c.LastName })
            //.ToList();

            //Console.WriteLine(agronomID);
            //Console.WriteLine(n);


            //        return View(consumerDetails.ToList());
            return View(distinctCustomers.ToList());
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
        public IActionResult ShowProductsPurchasedByConsumerC(int consumerID)
        {
            var products = context.Purchases
                .Where(p => p.ConsumerID == consumerID)
                .Select(p => p.ProductID)
                .Distinct()
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
