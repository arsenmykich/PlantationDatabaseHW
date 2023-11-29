using databaseHempPlantations.Models;
using HempPlantationsDatabase.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
