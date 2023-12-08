using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly PlantationContext context;

        public ReviewsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var reviews = this.context.Reviews.Select(r => new Review
            {
                ReviewID = r.ReviewID,
                ConsumerID = r.ConsumerID,
                AgronomistID = r.AgronomistID,
                ReviewDate = r.ReviewDate,
                Rating = r.Rating,
                Comment = r.Comment
                // Add other fields as needed
            });

            return View(reviews);
        }

        public IActionResult Create()
        {
            // You can customize this based on your actual model and context
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName");
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,ConsumerID,AgronomistID,ReviewDate,Rating,Comment")] Review review)
        {

            context.Reviews.Add(review);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            // You can customize this based on your actual model and context
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "ConsumerID", review.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", review.AgronomistID);

            return View(review);
        }
    }
}
