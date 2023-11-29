using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HempPlantationsDatabase.Controllers
{
    public class PurchasesController : Controller
    {
        private readonly PlantationContext context;

        public PurchasesController(PlantationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var purchases = this.context.Purchases.Select(p => new Purchase
            {
                PurchaseID = p.PurchaseID,
                ConsumerID = p.ConsumerID,
                AgronomistID = p.AgronomistID,
                ProductID = p.ProductID,
                PurchaseDate = p.PurchaseDate,
                Quantity = p.Quantity,
                TotalPrice = p.TotalPrice
                // Add other fields as needed
            });

            return View(purchases);
        }
    }
}
