using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public interface IBorrowRequestRepository
    {
        IEnumerable<BorrowRequest> GetAllRequests();
        void AddRequest(BorrowRequest request);
        BorrowRequest? GetRequestById(int id);
        void UpdateRequest(BorrowRequest request);
    }
}