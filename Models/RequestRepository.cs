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
            _requests.Add(request);
        }
    }
}