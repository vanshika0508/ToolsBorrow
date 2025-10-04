

/*using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBorrowRequestRepository _requestRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public AdminController(IBorrowRequestRepository requestRepository, IEquipmentRepository equipmentRepository)
        {
            _requestRepository = requestRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult Index()
        {
            var requests = _requestRepository.GetAllRequests();
            return View(requests);
        }

        [HttpPost]
        public IActionResult AcceptRequest(int id)
        {
            var request = _requestRepository.GetRequestById(id);
            if (request != null)
            {
                request.Status = "Accepted";
                
                // Mark equipment as unavailable
                var equipment = _equipmentRepository.GetEquipmentById(request.EquipmentId);
                if (equipment != null)
                {
                    equipment.Availability = false;
                    _equipmentRepository.UpdateEquipment(equipment);
                }
                
                _requestRepository.UpdateRequest(request);
                TempData["Message"] = $"Request #{id} has been accepted successfully.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DenyRequest(int id)
        {
            var request = _requestRepository.GetRequestById(id);
            if (request != null)
            {
                request.Status = "Denied";
                _requestRepository.UpdateRequest(request);
                TempData["Message"] = $"Request #{id} has been denied.";
            }
            return RedirectToAction("Index");
        }
    }
}*/

/*using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBorrowRequestRepository _requestRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public AdminController(IBorrowRequestRepository requestRepository, IEquipmentRepository equipmentRepository)
        {
            _requestRepository = requestRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult Index()
        {
            var requests = _requestRepository.GetAllRequests();
            return View(requests);
        }

        // Equipment Management
        public IActionResult EquipmentManagement()
        {
            var equipment = _equipmentRepository.GetAllEquipment();
            return View(equipment);
        }

        public IActionResult AddEquipment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEquipment(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                // In a real scenario, you'd add this to database
                // For now, we'll just redirect back
                TempData["Message"] = "Equipment added successfully!";
                return RedirectToAction("EquipmentManagement");
            }
            return View(equipment);
        }

        [HttpPost]
        public IActionResult AcceptRequest(int id)
        {
            var request = _requestRepository.GetRequestById(id);
            if (request != null)
            {
                request.Status = "Accepted";
                
                // Mark equipment as unavailable
                var equipment = _equipmentRepository.GetEquipmentById(request.EquipmentId);
                if (equipment != null)
                {
                    equipment.Availability = false;
                    _equipmentRepository.UpdateEquipment(equipment);
                }
                
                _requestRepository.UpdateRequest(request);
                TempData["Message"] = $"Request #{id} has been accepted successfully.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DenyRequest(int id)
        {
            var request = _requestRepository.GetRequestById(id);
            if (request != null)
            {
                request.Status = "Denied";
                _requestRepository.UpdateRequest(request);
                TempData["Message"] = $"Request #{id} has been denied.";
            }
            return RedirectToAction("Index");
        }
    }
}*/


using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBorrowRequestRepository _requestRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public AdminController(IBorrowRequestRepository requestRepository, IEquipmentRepository equipmentRepository)
        {
            _requestRepository = requestRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult Index()
        {
            var requests = _requestRepository.GetAllRequests();
            return View(requests);
        }

        [HttpPost]
        public IActionResult AcceptRequest(int id)
        {
            var request = _requestRepository.GetRequestById(id);
            if (request != null)
            {
                request.Status = "Accepted";
                
                var equipment = _equipmentRepository.GetEquipmentById(request.EquipmentId);
                if (equipment != null)
                {
                    equipment.Availability = false;
                    _equipmentRepository.UpdateEquipment(equipment);
                }
                
                _requestRepository.UpdateRequest(request);
                TempData["Message"] = $"Request #{id} has been accepted successfully.";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DenyRequest(int id)
        {
            var request = _requestRepository.GetRequestById(id);
            if (request != null)
            {
                request.Status = "Denied";
                _requestRepository.UpdateRequest(request);
                TempData["Message"] = $"Request #{id} has been denied.";
            }
            return RedirectToAction("Index");
        }
    }
}