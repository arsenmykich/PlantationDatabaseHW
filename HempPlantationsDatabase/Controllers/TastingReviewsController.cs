using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
