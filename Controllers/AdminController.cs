using Microsoft.AspNetCore.Mvc;
using ToolsBorrow.Models;

namespace ToolsBorrow.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var requests = RequestRepository.Requests ?? new List<BorrowRequest>();
            return View(requests);
        }

        [HttpPost]
        public IActionResult AcceptRequest(int id)
        {
            RequestRepository.UpdateRequestStatus(id, "Accepted");
            TempData["Message"] = $"Request #{id} has been accepted successfully.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DenyRequest(int id)
        {
            RequestRepository.UpdateRequestStatus(id, "Denied");
            TempData["Message"] = $"Request #{id} has been denied.";
            return RedirectToAction("Index");
        }
    }
}