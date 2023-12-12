using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class TastingReviewsController : Controller
    {
        private readonly PlantationContext context;

        public TastingReviewsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var tastingReviews = this.context.TastingReviews.Select(tr => new TastingReview
            {
                TastingReviewID = tr.TastingReviewID,
                TastingID = tr.TastingID,
                ReviewID = tr.ReviewID
                // Add other fields as needed
            });

            return View(tastingReviews);
        }


        public IActionResult Create()
        {
            ViewData["TastingID"] = new SelectList(context.Tastings, "TastingID", "TastingID");
            ViewData["ReviewID"] = new SelectList(context.Reviews, "ReviewID", "ReviewID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TastingReviewID,TastingID,ReviewID")] TastingReview tastingReview)
        {
            
                context.TastingReviews.Add(tastingReview);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            ViewData["TastingID"] = new SelectList(context.Tastings, "TastingID", "TastingID", tastingReview.TastingID);
            ViewData["ReviewID"] = new SelectList(context.Reviews, "ReviewID", "ReviewID", tastingReview.ReviewID);

            return View(tastingReview);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tastingReview = context.TastingReviews.Find(id);

            if (tastingReview == null)
            {
                return NotFound();
            }

            ViewData["ReviewID"] = new SelectList(context.Reviews, "ReviewID", "Comment", tastingReview.ReviewID);
            ViewData["TastingID"] = new SelectList(context.Tastings, "TastingID", "TastingID", tastingReview.TastingID);

            return View(tastingReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TastingReviewID,TastingID,ReviewID")] TastingReview tastingReview)
        {
            if (id != tastingReview.TastingReviewID)
            {
                return NotFound();
            }


                    context.Update(tastingReview);
                    await context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            

            ViewData["ReviewID"] = new SelectList(context.Reviews, "ReviewID", "Comment", tastingReview.ReviewID);
            ViewData["TastingID"] = new SelectList(context.Tastings, "TastingID", "TastingID", tastingReview.TastingID);

            return View(tastingReview);
        }

        private bool TastingReviewExists(int id)
        {
            return context.TastingReviews.Any(e => e.TastingReviewID == id);
        }

    }
}
