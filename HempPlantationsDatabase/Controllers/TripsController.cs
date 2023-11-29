using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class TripsController : Controller
    {
        private readonly PlantationContext context;

        public TripsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var trips = this.context.Trips.Select(t => new Trip
            {
                TripID = t.TripID,
                AgronomistID = t.AgronomistID,
                HarvestID = t.HarvestID,
                TripDate = t.TripDate,
                Destination = t.Destination
                // Add other fields as needed
            });

            return View(trips);
        }
    }
}
