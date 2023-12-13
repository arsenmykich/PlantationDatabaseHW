using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}