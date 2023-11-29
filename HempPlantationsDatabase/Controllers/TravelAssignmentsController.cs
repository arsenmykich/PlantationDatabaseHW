using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class TravelAssignmentsController : Controller
    {
        private readonly PlantationContext context;

        public TravelAssignmentsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var travelAssignments = this.context.TravelAssignments.Select(ta => new TravelAssignment
            {
                TravelAssignmentID = ta.TravelAssignmentID,
                AgronomistID = ta.AgronomistID,
                TripID = ta.TripID
                // Add other fields as needed
            });

            return View(travelAssignments);
        }
    }
}
