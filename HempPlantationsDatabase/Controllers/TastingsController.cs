using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
