using Microsoft.AspNetCore.Mvc;

namespace EquipmentApp.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: /Equipment/AllEquipment
        public IActionResult AllEquipment()
        {
            return View();
        }

        // GET: /Equipment/AvailableEquipment
        public IActionResult AvailableEquipment()
        {
            return View();
        }
    }
}
