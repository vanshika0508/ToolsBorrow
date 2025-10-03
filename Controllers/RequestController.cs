using Microsoft.AspNetCore.Mvc;
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
            if (ModelState.IsValid)
            {
                RequestRepository.AddRequest(request);
                return RedirectToAction("Confirmation");
            }
            return View(request);
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
}