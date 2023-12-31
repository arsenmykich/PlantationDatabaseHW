﻿using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class ReturnsController : Controller
    {
        private readonly PlantationContext context;

        public ReturnsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var returns = this.context.Returns.Select(r => new Return
            {
                ReturnID = r.ReturnID,
                ConsumerID = r.ConsumerID,
                AgronomistID = r.AgronomistID,
                ProductID = r.ProductID,
                ReturnDate = r.ReturnDate,
                Quantity = r.Quantity
                // Add other fields as needed
            });

            return View(returns);
        }


        public IActionResult Create()
        {
            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName");
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName");
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnID,AgronomistID,ConsumerID,ProductID,ReturnDate,Quantity")] Return returnItem)
        {
            context.Returns.Add(returnItem);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            // You can customize this based on your actual model and context
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "AgronomistID", returnItem.AgronomistID);
            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "ConsumerID", returnItem.ConsumerID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductID", returnItem.ProductID);

            return View(returnItem);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnItem = context.Returns.Find(id);

            if (returnItem == null)
            {
                return NotFound();
            }

            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName", returnItem.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", returnItem.AgronomistID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", returnItem.ProductID);

            return View(returnItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReturnID,ConsumerID,AgronomistID,ProductID,ReturnDate,Quantity")] Return returnItem)
        {
            if (id != returnItem.ReturnID)
            {
                return NotFound();
            }

  
                    context.Update(returnItem);
                    await context.SaveChangesAsync();
     

                return RedirectToAction(nameof(Index));
            

            ViewData["ConsumerID"] = new SelectList(context.Consumers, "ConsumerID", "FullName", returnItem.ConsumerID);
            ViewData["AgronomistID"] = new SelectList(context.Agronomists, "AgronomistID", "FullName", returnItem.AgronomistID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", returnItem.ProductID);

            return View(returnItem);
        }

        private bool ReturnExists(int id)
        {
            return context.Returns.Any(e => e.ReturnID == id);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var returnItem = await context.Returns
                .Include(r => r.Consumer)
                .Include(r => r.Agronomist)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(m => m.ReturnID == id);

            if (returnItem == null)
            {
                return NotFound();
            }

            return View(returnItem);
        }

        // POST: Returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var returnItem = await context.Returns.FindAsync(id);
            context.Returns.Remove(returnItem);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
