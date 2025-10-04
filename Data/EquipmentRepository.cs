
using Microsoft.EntityFrameworkCore;
using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipment> GetAllEquipment()
        {
            // LINQ: Order by EquipmentId
            return _context.Equipment
                         .OrderBy(e => e.EquipmentId)
                         .ToList();
        }

        public IEnumerable<Equipment> GetAvailableEquipment()
        {
            // LINQ: Filter by Availability and order by Type
            return _context.Equipment
                         .Where(e => e.Availability == true)
                         .OrderBy(e => e.Type)
                         .ThenBy(e => e.EquipmentId)
                         .ToList();
        }

        public IEnumerable<Equipment> GetEquipmentByType(string type)
        {
            // LINQ: Filter by specific equipment type
            return _context.Equipment
                         .Where(e => e.Type == type && e.Availability == true)
                         .OrderBy(e => e.Description)
                         .ToList();
        }

        public IEnumerable<Equipment> SearchEquipment(string searchTerm)
        {
            // LINQ: Search in both Type and Description
            return _context.Equipment
                         .Where(e => e.Type.Contains(searchTerm) || 
                                    e.Description.Contains(searchTerm))
                         .OrderBy(e => e.Type)
                         .ThenBy(e => e.Description)
                         .ToList();
        }

        public Equipment? GetEquipmentById(int id)
        {
            // LINQ: Single item by ID
            return _context.Equipment
                         .FirstOrDefault(e => e.EquipmentId == id);
        }

        public void UpdateEquipment(Equipment equipment)
        {
            _context.Equipment.Update(equipment);
            _context.SaveChanges();
        }

        // New method: Get equipment statistics
        public object GetEquipmentStatistics()
        {
            // LINQ: Group by and aggregate functions
            var stats = _context.Equipment
                .GroupBy(e => e.Type)
                .Select(g => new
                {
                    Type = g.Key,
                    Total = g.Count(),
                    Available = g.Count(e => e.Availability),
                    Unavailable = g.Count(e => !e.Availability)
                })
                .OrderBy(s => s.Type)
                .ToList();

            return stats;
        }
    }
}