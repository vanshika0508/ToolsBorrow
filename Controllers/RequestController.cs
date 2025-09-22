using Microsoft.AspNetCore.Mvc;
using EquipmentApp.Models;


namespace EquipmentApp.Controllers
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
                return RedirectToAction("Confirmation");
            }

            // ModelState contains validation errors → redisplay form
            return View(request);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}


