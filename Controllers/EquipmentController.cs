using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult AllEquipment()
        {
            var equipment = EquipmentRepository.GetAllEquipment() ?? new List<Equipment>();
            return View(equipment);
        }

        public IActionResult AvailableEquipment()
        {
            var availableEquipment = EquipmentRepository.GetAvailableEquipment() ?? new List<Equipment>();
            return View(availableEquipment);
        }
    }
}