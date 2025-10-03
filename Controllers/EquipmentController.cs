using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Services;       

/*namespace EquipmentApp.Controllers
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
}*/
namespace ToolsBorrow.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        // GET: /Equipment/AllEquipment
        public IActionResult AllEquipment()
        {
            var equipments = _equipmentRepository.GetAll();
            return View(equipments);
        }

        // GET: /Equipment/AvailableEquipment
        public IActionResult AvailableEquipment()
        {
            var availableEquipments = _equipmentRepository.GetAvailable();
            return View(availableEquipments);
        }
    }
}
