
using Microsoft.EntityFrameworkCore;
using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public class BorrowRequestRepository : IBorrowRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public BorrowRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BorrowRequest> GetAllRequests()
        {
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .OrderByDescending(r => r.RequestDate)
                         .ThenByDescending(r => r.RequestId)
                         .ToList();
        }

        public IEnumerable<BorrowRequest> GetPendingRequests()
        {
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .Where(r => r.Status == "Pending")
                         .OrderByDescending(r => r.RequestDate)
                         .ToList();
        }

        public IEnumerable<BorrowRequest> GetRequestsByStatus(string status)
        {
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .Where(r => r.Status == status)
                         .OrderByDescending(r => r.RequestDate)
                         .ToList();
        }

        public IEnumerable<BorrowRequest> GetRequestsByUser(string email)
        {
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .Where(r => r.Email == email)
                         .OrderByDescending(r => r.RequestDate)
                         .ToList();
        }

        public IEnumerable<BorrowRequest> SearchRequests(string searchTerm)
        {
            // FIXED: Added null checks for Equipment
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .Where(r => r.Name.Contains(searchTerm) || 
                                    r.Email.Contains(searchTerm) ||
                                    (r.Equipment != null && r.Equipment.Type.Contains(searchTerm)) ||
                                    (r.Equipment != null && r.Equipment.Description.Contains(searchTerm)))
                         .OrderByDescending(r => r.RequestDate)
                         .ToList();
        }

        public void AddRequest(BorrowRequest request)
        {
            _context.BorrowRequests.Add(request);
            _context.SaveChanges();
        }

        public BorrowRequest? GetRequestById(int id)
        {
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .FirstOrDefault(r => r.RequestId == id);
        }

        public void UpdateRequest(BorrowRequest request)
        {
            _context.BorrowRequests.Update(request);
            _context.SaveChanges();
        }

        public object GetRequestStatistics()
        {
            var stats = _context.BorrowRequests
                .GroupBy(r => r.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                })
                .OrderBy(s => s.Status)
                .ToList();

            return stats;
        }

        public IEnumerable<BorrowRequest> GetRecentRequests(int days = 7)
        {
            var cutoffDate = DateTime.Now.AddDays(-days);
            
            return _context.BorrowRequests
                         .Include(r => r.Equipment)
                         .Where(r => r.RequestDate >= cutoffDate)
                         .OrderByDescending(r => r.RequestDate)
                         .ToList();
        }
    }
}