

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
            
        
            ViewBag.AvailableEquipment = _equipmentRepository.GetAvailableEquipment();
            return View(request);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}