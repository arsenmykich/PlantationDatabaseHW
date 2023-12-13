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
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName");
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName");
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName");
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasting = context.Tastings.Find(id);

            if (tasting == null)
            {
                return NotFound();
            }

            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName", tasting.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", tasting.AgronomistID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", tasting.ProductID);

            return View(tasting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TastingID,AgronomistID,ConsumerID,ProductID,TastingDate,Rating")] Tasting tasting)
        {
            if (id != tasting.TastingID)
            {
                return NotFound();
            }


                    context.Update(tasting);
                    await context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            

            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName", tasting.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", tasting.AgronomistID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", tasting.ProductID);

            return View(tasting);
        }

        private bool TastingExists(int id)
        {
            return context.Tastings.Any(e => e.TastingID == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasting = await context.Tastings
                .Include(t => t.Consumer)
                .Include(t => t.Agronomist)
                .Include(t => t.Product)
                .FirstOrDefaultAsync(m => m.TastingID == id);

            if (tasting == null)
            {
                return NotFound();
            }

            return View(tasting);
        }

        // POST: Tastings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasting = await context.Tastings.FindAsync(id);
            context.Tastings.Remove(tasting);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
