using System.Collections.Generic;

namespace ToolsBorrow.Models
{
    public class RequestRepository
    {
        private static List<BorrowRequest> _requests = new List<BorrowRequest>();
        private static int _nextId = 1;

        public static IEnumerable<BorrowRequest> Requests => _requests;

        public static void AddRequest(BorrowRequest request)
        {
            request.Id = _nextId++;
            request.Status = "Pending"; // Default status
            _requests.Add(request);
        }

        public static void UpdateRequestStatus(int id, string status)
        {
            var request = _requests.FirstOrDefault(r => r.Id == id);
            if (request != null)
            {
                request.Status = status;
            }
        }
    }
}