using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PlantationContext context;

        public ProductsController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var products = this.context.Products.Select(p => new Product
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price,
                Description = p.Description
                // Add other fields as needed
            });

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,Price,Description")] Product product)
        {
            
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            

            return View(product);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,Price,Description")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }


            context.Update(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            

            return View(product);
        }

        private bool ProductExists(int id)
        {
            return context.Products.Any(e => e.ProductID == id);
        }

    }
}
