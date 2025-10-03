using ToolsBorrow.Models;

namespace ToolsBorrow.Services
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAll();
        IEnumerable<Equipment> GetAvailable();
        Equipment? FindById(int id);
        void Add(Equipment equipment);
        void Update(Equipment equipment);
    }
}