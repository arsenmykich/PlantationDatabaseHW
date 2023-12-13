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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = context.Purchases.Find(id);

            if (purchase == null)
            {
                return NotFound();
            }

            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName", purchase.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", purchase.AgronomistID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", purchase.ProductID);

            return View(purchase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseID,ConsumerID,AgronomistID,ProductID,PurchaseDate,Quantity,TotalPrice")] Purchase purchase)
        {
            if (id != purchase.PurchaseID)
            {
                return NotFound();
            }


                context.Update(purchase);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName", purchase.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", purchase.AgronomistID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", purchase.ProductID);

            return View(purchase);
        }

        private bool PurchaseExists(int id)
        {
            return context.Purchases.Any(e => e.PurchaseID == id);
        }





    }
}
