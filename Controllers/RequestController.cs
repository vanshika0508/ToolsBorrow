

using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class RequestController : Controller
    {
        private readonly IBorrowRequestRepository _requestRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public RequestController(IBorrowRequestRepository requestRepository, IEquipmentRepository equipmentRepository)
        {
            _requestRepository = requestRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IActionResult RequestForm()
        {
            // Pass available equipment to the view for dropdown
            ViewBag.AvailableEquipment = _equipmentRepository.GetAvailableEquipment();
            return View();
        }

        [HttpPost]
        public IActionResult RequestForm(BorrowRequest request)
        {
            if (ModelState.IsValid)
            {
                _requestRepository.AddRequest(request);
                return RedirectToAction("Confirmation");
            }
            
            // If validation fails, reload available equipment
            ViewBag.AvailableEquipment = _equipmentRepository.GetAvailableEquipment();
            return View(request);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}