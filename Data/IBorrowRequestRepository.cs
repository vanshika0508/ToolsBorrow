
using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public interface IBorrowRequestRepository
    {
        IEnumerable<BorrowRequest> GetAllRequests();
        IEnumerable<BorrowRequest> GetPendingRequests();
        IEnumerable<BorrowRequest> GetRequestsByStatus(string status);
        IEnumerable<BorrowRequest> GetRequestsByUser(string email);
        IEnumerable<BorrowRequest> SearchRequests(string searchTerm);
        IEnumerable<BorrowRequest> GetRecentRequests(int days = 7); // New method
        void AddRequest(BorrowRequest request);
        BorrowRequest? GetRequestById(int id);
        void UpdateRequest(BorrowRequest request);
        object GetRequestStatistics(); // New method
    }
}