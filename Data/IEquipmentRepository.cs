using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAllEquipment();
        IEnumerable<Equipment> GetAvailableEquipment();
        Equipment? GetEquipmentById(int id);
        void UpdateEquipment(Equipment equipment);
    }
}