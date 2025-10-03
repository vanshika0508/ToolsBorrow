using ToolsBorrow.Data;
using ToolsBorrow.Models;

namespace ToolsBorrow.Services
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly FastEquipmentContext _context;

        public EquipmentRepository(FastEquipmentContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipment.OrderBy(e => e.Id).ToList();
        }

        public IEnumerable<Equipment> GetAvailable()
        {
            return _context.Equipment
                .Where(e => e.IsAvailable)
                .OrderBy(e => e.Id)
                .ToList();
        }

        public Equipment? FindById(int id)
        {
            return _context.Equipment.Find(id);
        }

        public void Add(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            _context.SaveChanges();
        }

        public void Update(Equipment equipment)
        {
            _context.Equipment.Update(equipment);
            _context.SaveChanges();
        }
    }
}