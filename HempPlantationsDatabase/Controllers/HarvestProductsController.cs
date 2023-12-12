using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class HarvestProductsController : Controller
    {
        private readonly PlantationContext context;

        public HarvestProductsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var harvestProducts = this.context.HarvestProducts.Select(hp => new HarvestProduct
            {
                HarvestProductID = hp.HarvestProductID,
                HarvestID = hp.HarvestID,
                ProductID = hp.ProductID,
                Quantity = hp.Quantity
            });

            return View(harvestProducts);
        }

        public IActionResult Create()
        {
            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID");
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HarvestProductID,HarvestID,ProductID,Quantity")] HarvestProduct harvestProduct)
        {
           
                context.HarvestProducts.Add(harvestProduct);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID", harvestProduct.HarvestID);
            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", harvestProduct.ProductID);

            return View(harvestProduct);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestProduct = context.HarvestProducts.Find(id);

            if (harvestProduct == null)
            {
                return NotFound();
            }

            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", harvestProduct.ProductID);
            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID", harvestProduct.HarvestID);

            return View(harvestProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HarvestProductID,HarvestID,ProductID,Quantity")] HarvestProduct harvestProduct)
        {
            if (id != harvestProduct.HarvestProductID)
            {
                return NotFound();
            }


                    context.Update(harvestProduct);
                    await context.SaveChangesAsync();
                
                

                return RedirectToAction(nameof(Index));
            

            ViewData["ProductID"] = new SelectList(context.Products, "ProductID", "ProductName", harvestProduct.ProductID);
            ViewData["HarvestID"] = new SelectList(context.Harvests, "HarvestID", "HarvestID", harvestProduct.HarvestID);

            return View(harvestProduct);
        }

        private bool HarvestProductExists(int id)
        {
            return context.HarvestProducts.Any(e => e.HarvestProductID == id);
        }





    }
}
