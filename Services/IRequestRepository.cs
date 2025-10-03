using ToolsBorrow.Models;

namespace ToolsBorrow.Services
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetAll();
        IEnumerable<Request> GetPending();
        void Add(Request request);
        void UpdateStatus(int requestId, RequestStatus status);
        Request? FindById(int id);
    }
}