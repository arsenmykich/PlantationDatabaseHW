using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class TastingsController : Controller
    {
        private readonly PlantationContext context;

        public TastingsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var tastings = this.context.Tastings.Select(t => new Tasting
            {
                TastingID = t.TastingID,
                AgronomistID = t.AgronomistID,
                ConsumerID = t.ConsumerID,
                ProductID = t.ProductID,
                TastingDate = t.TastingDate,
                Rating = t.Rating
                // Add other fields as needed
            });

            return View(tastings);
        }



        public IActionResult Create()
        {
            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID");
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "ConsumerID");
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TastingID,AgronomistID,ConsumerID,ProductID,TastingDate,Rating")] Tasting tasting)
        {
            //if (ModelState.IsValid)
            //{
                context.Tastings.Add(tasting);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}

            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", tasting.AgronomistID);
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "ConsumerID", tasting.ConsumerID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductID", tasting.ProductID);

            return View(tasting);
        }


    }
}
