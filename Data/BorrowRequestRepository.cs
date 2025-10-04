using ToolsBorrow.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            return _context.BorrowRequests.Include(r => r.Equipment).ToList();
        }

        public void AddRequest(BorrowRequest request)
        {
            _context.BorrowRequests.Add(request);
            _context.SaveChanges();
        }

        public BorrowRequest? GetRequestById(int id)
        {
            return _context.BorrowRequests.Include(r => r.Equipment).FirstOrDefault(r => r.RequestId == id);
        }

        public void UpdateRequest(BorrowRequest request)
        {
            _context.BorrowRequests.Update(request);
            _context.SaveChanges();
        }
    }
}