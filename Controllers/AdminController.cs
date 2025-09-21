using Microsoft.AspNetCore.Mvc;
using EquipmentApp.Models;

namespace EquipmentApp.Controllers
{
    public class AdminController : Controller
    {
        [Route("Requests")]
        public IActionResult Requests()
        {
            var allRequests = RequestRepository.GetAll();
            return View(allRequests);
        }

        [HttpPost]
        [Route("Requests/Accept/{id}")]
        public IActionResult Accept(int id)
        {
            RequestRepository.UpdateStatus(id, "Accepted");
            TempData["Message"] = $"Request #{id} has been accepted.";
            TempData["MessageType"] = "success";
            return RedirectToAction("Requests");
        }

        [HttpPost]
        [Route("Requests/Deny/{id}")]
        public IActionResult Deny(int id)
        {
            RequestRepository.UpdateStatus(id, "Denied");
            TempData["Message"] = $"Request #{id} has been denied.";
            TempData["MessageType"] = "danger";
            return RedirectToAction("Requests");
        }
    }
}


