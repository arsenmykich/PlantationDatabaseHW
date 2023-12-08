using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly PlantationContext context;

        public PurchasesController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var purchases = this.context.Purchases.Select(p => new Purchase
            {
                PurchaseID = p.PurchaseID,
                ConsumerID = p.ConsumerID,
                AgronomistID = p.AgronomistID,
                ProductID = p.ProductID,
                PurchaseDate = p.PurchaseDate,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice
                // Add other fields as needed
            });

            return View(purchases);
        }

        public IActionResult Create()
        {
            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName");
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName");
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseID,AgronomistID,ConsumerID,ProductID,PurchaseDate,Quantity,TotalPrice")] Purchase purchase)
        {
            //if (ModelState.IsValid)
            //{
                context.Purchases.Add(purchase);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}

            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", purchase.AgronomistID);
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "ConsumerID", purchase.ConsumerID);
            ViewData["ProductID"] = new SelectList (context.Products, "ProductID", "ProductID", purchase.ProductID);

            return View(purchase);
        }







    }
}
