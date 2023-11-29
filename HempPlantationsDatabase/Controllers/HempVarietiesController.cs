using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class HempVarietiesController : Controller
    {
        private readonly PlantationContext context;

        public HempVarietiesController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var hempVarieties = this.context.HempVarieties.Select(hv => new HempVariety
            {
                VarietyID = hv.VarietyID,
                VarietyName = hv.VarietyName,
                Description = hv.Description
                // Add other fields as needed
            });

            return View(hempVarieties);
        }
    }
}
