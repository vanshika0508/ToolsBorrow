using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Services
{
    public class RequestRepository : IRequestRepository
    {
        private readonly FastEquipmentContext _context;

        public RequestRepository(FastEquipmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Request> GetAll()
        {
            return _context.Requests
                .Include(r => r.Equipment)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
        }

        public IEnumerable<Request> GetPending()
        {
            return _context.Requests
                .Include(r => r.Equipment)
                .Where(r => r.Status == RequestStatus.Pending)
                .OrderBy(r => r.CreatedAt)
                .ToList();
        }

        public void Add(Request request)
        {
            _context.Requests.Add(request);
            _context.SaveChanges();
        }

        public void UpdateStatus(int requestId, RequestStatus status)
        {
            var request = _context.Requests.Find(requestId);
            if (request != null)
            {
                request.Status = status;
                _context.SaveChanges();
            }
        }

        public Request? FindById(int id)
        {
            return _context.Requests
                .Include(r => r.Equipment)
                .FirstOrDefault(r => r.Id == id);
        }
    }
}