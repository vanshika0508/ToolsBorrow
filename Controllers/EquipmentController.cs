
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
            // Ordered by EquipmentId
            var equipment = _equipmentRepository.GetAllEquipment();
            return View(equipment);
        }

        public IActionResult AvailableEquipment()
        {
            // Only available equipment, ordered by Type
            var availableEquipment = _equipmentRepository.GetAvailableEquipment();
            return View(availableEquipment);
        }

        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("AllEquipment");
            }

            // Search equipment by type or description
            var results = _equipmentRepository.SearchEquipment(searchTerm);
            ViewBag.SearchTerm = searchTerm;
            return View(results);
        }

        public IActionResult ByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return RedirectToAction("AllEquipment");
            }

            // Filter by specific equipment type
            var equipment = _equipmentRepository.GetEquipmentByType(type);
            ViewBag.EquipmentType = type;
            return View(equipment);
        }
    }
}