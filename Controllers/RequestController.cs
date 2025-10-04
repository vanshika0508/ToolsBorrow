/*using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult RequestForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RequestForm(BorrowRequest request)
        {
            // Debug: Check if model is valid
            if (!ModelState.IsValid)
            {
                // Log validation errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    System.Diagnostics.Debug.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                return View(request);
            }

            // If model is valid, save the request
            RequestRepository.AddRequest(request);
            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult Requests()
        {
            var requests = RequestRepository.Requests;
            return View(requests);
        }
    }
}*/

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