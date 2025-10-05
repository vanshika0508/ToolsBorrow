

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
            // Orders by latest requests first
            var requests = _requestRepository.GetAllRequests();
            
            ViewBag.RequestStats = _requestRepository.GetRequestStatistics();
            ViewBag.EquipmentStats = _equipmentRepository.GetEquipmentStatistics();
            
            return View(requests);
        }

        public IActionResult PendingRequests()
        {
            // Only pending requests, latest first
            var pendingRequests = _requestRepository.GetPendingRequests();
            return View(pendingRequests);
        }

        public IActionResult SearchRequests(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("Index");
            }

            // Search across multiple fields
            var results = _requestRepository.SearchRequests(searchTerm);
            ViewBag.SearchTerm = searchTerm;
            return View(results);
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