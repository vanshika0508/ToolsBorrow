using Microsoft.AspNetCore.Mvc;
using EquipmentApp.Models;

namespace EquipmentApp.Controllers
{
    public class RequestController : Controller
    {
        // GET: /Request/RequestForm
        public IActionResult RequestForm()
        {
            return View();
        }

        // POST: /Request/RequestForm
        [HttpPost]
        public IActionResult RequestForm(EquipmentRequest request)
        {
            if (ModelState.IsValid && request.Duration > 0)
            {
                RequestRepository.Add(request);
                return RedirectToAction("Confirmation");
            }

            ViewBag.Error = "Please check your inputs.";
            return View(request);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}

