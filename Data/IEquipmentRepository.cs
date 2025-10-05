
using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAllEquipment();
        IEnumerable<Equipment> GetAvailableEquipment();
        IEnumerable<Equipment> GetEquipmentByType(string type);
        IEnumerable<Equipment> SearchEquipment(string searchTerm);
        Equipment? GetEquipmentById(int id);
        void UpdateEquipment(Equipment equipment);
        object GetEquipmentStatistics(); 
    }
}