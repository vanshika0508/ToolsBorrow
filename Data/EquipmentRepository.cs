using ToolsBorrow.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Equipment.ToList();
        }

        public IEnumerable<Equipment> GetAvailableEquipment()
        {
            return _context.Equipment.Where(e => e.Availability).ToList();
        }

        public Equipment? GetEquipmentById(int id)
        {
            return _context.Equipment.FirstOrDefault(e => e.EquipmentId == id);
        }

        public void UpdateEquipment(Equipment equipment)
        {
            _context.Equipment.Update(equipment);
            _context.SaveChanges();
        }
    }
}