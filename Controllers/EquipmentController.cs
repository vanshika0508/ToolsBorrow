/*using Microsoft.AspNetCore.Mvc;
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
}*/
using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult AllEquipment()
        {
            var equipment = _equipmentRepository.GetAllEquipment();
            return View(equipment);
        }

        public IActionResult AvailableEquipment()
        {
            var availableEquipment = _equipmentRepository.GetAvailableEquipment();
            return View(availableEquipment);
        }
    }
}