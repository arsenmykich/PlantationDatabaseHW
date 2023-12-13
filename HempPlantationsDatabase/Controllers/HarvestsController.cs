using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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


        //public IActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Harvest harvest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Perform any necessary validation and save the new Harvest to the database
        //            context.Harvests.Add(harvest);
        //            context.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            // Log the exception or handle it as needed
        //            ModelState.AddModelError(string.Empty, "An error occurred while saving the Harvest.");
        //        }
        //    }

        //    return View(harvest);
        //}

        // GET: Harvests/Create
        public IActionResult Create()
        {
            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName");
            ViewData["VarietyID"] = new SelectList(context.HempVarieties, "VarietyID", "VarietyName");
            return View();
        }

        // POST: Harvests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HarvestID,AgronomistID,VarietyID,HarvestDate,Quantity")] Harvest harvest)
        {
            //if (ModelState.IsValid)
            //{
                context.Harvests.Add(harvest);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}

            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", harvest.AgronomistID);
            ViewData["VarietyID"] = new SelectList(context.HempVarieties, "VarietyID", "VarietyID", harvest.VarietyID);

            return View(harvest);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvest = context.Harvests.Find(id);

            if (harvest == null)
            {
                return NotFound();
            }

            return View(harvest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HarvestID,AgronomistID,VarietyID,HarvestDate,Quantity")] Harvest harvest)
        {
            if (id != harvest.HarvestID)
            {
                return NotFound();
            }

                
                    context.Update(harvest);
                    await context.SaveChangesAsync();
                


                

                return RedirectToAction(nameof(Index));
            

            return View(harvest);
        }

        private bool HarvestExists(int id)
        {
            return context.Harvests.Any(e => e.HarvestID == id);
        }


        /*            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(harvest);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarvestExists(harvest.HarvestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }*/





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
