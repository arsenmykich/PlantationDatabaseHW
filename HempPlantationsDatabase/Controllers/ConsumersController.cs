using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class ConsumersController : Controller
    {
        private readonly PlantationContext context;

        public ConsumersController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var consumers = this.context.Consumers.Select(c => new Consumer
            {
                ConsumerID = c.ConsumerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                RegistrationDate = c.RegistrationDate
                // Add other fields as needed
            });

            return View(consumers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumerID,FirstName,LastName,Email,PhoneNumber,RegistrationDate")] Consumer consumer)
        {
            
                context.Consumers.Add(consumer);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            return View(consumer);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = context.Consumers.Find(id);

            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumerID,FirstName,LastName,Email,PhoneNumber,RegistrationDate")] Consumer consumer)
        {
            if (id != consumer.ConsumerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(consumer);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumerExists(consumer.ConsumerID))
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

            return View(consumer);
        }

        private bool ConsumerExists(int id)
        {
            return context.Consumers.Any(e => e.ConsumerID == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumer = await context.Consumers
                .FirstOrDefaultAsync(m => m.ConsumerID == id);
            if (consumer == null)
            {
                return NotFound();
            }

            return View(consumer);
        }

        // POST: Consumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumer = await context.Consumers.FindAsync(id);
            context.Consumers.Remove(consumer);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}