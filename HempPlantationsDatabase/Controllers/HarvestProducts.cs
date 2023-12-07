using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
