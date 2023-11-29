using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
