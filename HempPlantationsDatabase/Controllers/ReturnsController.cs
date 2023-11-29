using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}
