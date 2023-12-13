using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            });

            return View(hempVarieties);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VarietyID,VarietyName,Description")] HempVariety hempVariety)
        {
            
                context.HempVarieties.Add(hempVariety);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            return View(hempVariety);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hempVariety = context.HempVarieties.Find(id);

            if (hempVariety == null)
            {
                return NotFound();
            }

            return View(hempVariety);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VarietyID,VarietyName,Description")] HempVariety hempVariety)
        {
            if (id != hempVariety.VarietyID)
            {
                return NotFound();
            }

                    context.Update(hempVariety);
                    await context.SaveChangesAsync();
                


                return RedirectToAction(nameof(Index));
            

            return View(hempVariety);
        }

        private bool HempVarietyExists(int id)
        {
            return context.HempVarieties.Any(e => e.VarietyID == id);
        }


    }
}
