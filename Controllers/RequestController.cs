using Microsoft.AspNetCore.Mvc;
using EquipmentApp.Models;
using ToolsBorrow.Services;
using ToolsBorrow.Models;


/*namespace EquipmentApp.Controllers
{
    public class RequestController : Controller
    {
        public IActionResult RequestForm()
        {
            return View(new EquipmentRequest());
        }

        [HttpPost]
        public IActionResult RequestForm(EquipmentRequest request)
        {
            if (ModelState.IsValid)
            {
                RequestRepository.Add(request);
                return RedirectToAction("Confirmation");//for the order confirmation
            }

            //the validation error
            return View(request);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}*/
namespace ToolsBorrow.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public RequestController(IRequestRepository requestRepository, IEquipmentRepository equipmentRepository)
        {
            _requestRepository = requestRepository;
            _equipmentRepository = equipmentRepository;
        }


        // GET: /Request/RequestForm
        [HttpGet]
        public IActionResult RequestForm()
        {
            ViewBag.AvailableEquipment = _equipmentRepository.GetAvailable();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RequestForm(Request request)
        {
            if (ModelState.IsValid)
            {
                var equipment = _equipmentRepository.FindById(request.EquipmentId);
                if (equipment == null || !equipment.IsAvailable)
                {
                    ModelState.AddModelError("EquipmentId", "Selected equipment is not available.");
                    ViewBag.AvailableEquipment = _equipmentRepository.GetAvailable();
                    return View(request);
                }
                //request.Status = RequestStatus.Pending;
                _requestRepository.Add(request);
                equipment.IsAvailable = false;
                _equipmentRepository.Update(equipment);
                return RedirectToAction("Confirmation", new { id = request.Id }); // for the order confirmation
            }

            // the validation error
            ViewBag.AvailableEquipment = _equipmentRepository.GetAvailable();
            return View(request);
        }

        public IActionResult Confirmation(int id)
        {
            var request = _requestRepository.FindById(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }
        public IActionResult Requests()
        {
            var pendingRequests = _requestRepository.GetPending();
            return View(pendingRequests);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, RequestStatus status)
        {
            _requestRepository.UpdateStatus(id, status);
            return RedirectToAction("Requests");
        }
    }
}


