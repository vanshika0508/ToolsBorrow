using Microsoft.AspNetCore.Mvc;

namespace EquipmentApp.Controllers
{
    public class EquipmentController : Controller
    {
        // GET AllEquipment from Equipments
        public IActionResult AllEquipment()
        {
            return View();
        }

        // GET only available equipments from the allequipments
        public IActionResult AvailableEquipment()
        {
            return View();
        }
    }
}
