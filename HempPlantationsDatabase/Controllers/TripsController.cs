using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Create()
        {
            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName");
            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripID,AgronomistID,HarvestID,TripDate,Destination")] Trip trip)
        {
            
                context.Trips.Add(trip);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", trip.AgronomistID);
            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID", trip.HarvestID);

            return View(trip);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = context.Trips.Find(id);

            if (trip == null)
            {
                return NotFound();
            }

            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID", trip.HarvestID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", trip.AgronomistID);

            return View(trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,AgronomistID,HarvestID,TripDate,Destination")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }


                    context.Update(trip);
                    await context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            

            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID", trip.HarvestID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", trip.AgronomistID);

            return View(trip);
        }

        private bool TripExists(int id)
        {
            return context.Trips.Any(e => e.TripID == id);
        }

    }
}
