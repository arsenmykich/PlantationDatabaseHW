using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
