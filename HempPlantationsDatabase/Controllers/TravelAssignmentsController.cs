using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Create()
        {
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID");
            ViewData["TripID"] = new SelectList(context.Trips, "TripID", "TripID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelAssignmentID,AgronomistID,TripID")] TravelAssignment travelAssignment)
        {
            
                context.TravelAssignments.Add(travelAssignment);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", travelAssignment.AgronomistID);
            ViewData["TripID"] = new SelectList(context.Trips, "TripID", "TripID", travelAssignment.TripID);

            return View(travelAssignment);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travelAssignment = context.TravelAssignments.Find(id);

            if (travelAssignment == null)
            {
                return NotFound();
            }

            ViewData["TripID"] = new SelectList(context.Trips, "TripID", "TripName", travelAssignment.TripID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", travelAssignment.AgronomistID);

            return View(travelAssignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelAssignmentID,AgronomistID,TripID")] TravelAssignment travelAssignment)
        {
            if (id != travelAssignment.TravelAssignmentID)
            {
                return NotFound();
            }


                    context.Update(travelAssignment);
                    await context.SaveChangesAsync();
 

                return RedirectToAction(nameof(Index));
            

            ViewData["TripID"] = new SelectList(context.Trips, "TripID", "TripName", travelAssignment.TripID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", travelAssignment.AgronomistID);

            return View(travelAssignment);
        }

        private bool TravelAssignmentExists(int id)
        {
            return context.TravelAssignments.Any(e => e.TravelAssignmentID == id);
        }

    }
}
