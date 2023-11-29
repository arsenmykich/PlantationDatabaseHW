using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class HarvestsController : Controller
    {
        private readonly PlantationContext context;

        public HarvestsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var harvests = this.context.Harvests.Select(h => new Harvest
            {
                HarvestID = h.HarvestID,
                AgronomistID = h.AgronomistID,
                VarietyID = h.VarietyID,
                HarvestDate = h.HarvestDate,
                Quantity = h.Quantity
                // Add other fields as needed
            });

            return View(harvests);
        }
    }
}
