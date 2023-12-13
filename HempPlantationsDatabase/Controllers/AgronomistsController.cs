using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HempPlantationsDatabase.Controllers
{
    public class AgronomistsController : Controller
    {
        private readonly PlantationContext context;

        public AgronomistsController(PlantationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var agronomist = this.context.Agronomists.Select(m => new Agronomist
            {
                AgronomistID = m.AgronomistID,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                HireDate = m.HireDate,
                Specialty = m.Specialty
            });

            return View(agronomist);
        }


        public IActionResult Create()
        {
            return View();
        }

        // POST: Agronomists/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgronomistID,FirstName,LastName,Email,PhoneNumber,HireDate,Specialty")] Agronomist agronomist)
        {

                context.Agronomists.Add(agronomist);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));


            return View(agronomist);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agronomist = context.Agronomists.Find(id);

            if (agronomist == null)
            {
                return NotFound();
            }

            return View(agronomist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgronomistID,FirstName,LastName,Email,PhoneNumber,HireDate,Specialty")] Agronomist agronomist)
        {
            if (id != agronomist.AgronomistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(agronomist);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgronomistExists(agronomist.AgronomistID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(agronomist);
        }

        private bool AgronomistExists(int id)
        {
            return context.Agronomists.Any(e => e.AgronomistID == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agronomist = await context.Agronomists
                .FirstOrDefaultAsync(m => m.AgronomistID == id);
            if (agronomist == null)
            {
                return NotFound();
            }

            return View(agronomist);
        }

        // POST: Agronomists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agronomist = await context.Agronomists.FindAsync(id);
            context.Agronomists.Remove(agronomist);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
