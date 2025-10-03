using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult AllEquipment()
        {
            var equipment = EquipmentRepository.GetAllEquipment();
            return View(equipment);
        }

        public IActionResult AvailableEquipment()
        {
            var availableEquipment = EquipmentRepository.GetAvailableEquipment();
            return View(availableEquipment);
        }
    }
}