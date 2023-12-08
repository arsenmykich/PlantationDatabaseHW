using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class ReturnsController : Controller
    {
        private readonly PlantationContext context;

        public ReturnsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var returns = this.context.Returns.Select(r => new Return
            {
                ReturnID = r.ReturnID,
                ConsumerID = r.ConsumerID,
                AgronomistID = r.AgronomistID,
                ProductID = r.ProductID,
                ReturnDate = r.ReturnDate,
                Quantity = r.Quantity
                // Add other fields as needed
            });

            return View(returns);
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
        public async Task<IActionResult> Create([Bind("ReturnID,AgronomistID,ConsumerID,ProductID,ReturnDate,Quantity")] Return returnItem)
        {
            context.Returns.Add(returnItem);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", returnItem.AgronomistID);
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "ConsumerID", returnItem.ConsumerID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductID", returnItem.ProductID);

            return View(returnItem);
        }
    }
}
