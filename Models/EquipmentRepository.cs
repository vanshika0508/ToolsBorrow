using System.Collections.Generic;

namespace ToolsBorrow.Models
{
    public class EquipmentRepository
    {
        private static List<Equipment> _equipment = new List<Equipment>
        {
            new Equipment { Id = 1, Type = "Laptop", Description = "Dell Latitude 14-inch", Availability = true },
            new Equipment { Id = 2, Type = "Laptop", Description = "MacBook Pro 13-inch", Availability = false },
            new Equipment { Id = 3, Type = "Tablet", Description = "iPad Air", Availability = true },
            new Equipment { Id = 4, Type = "Phone", Description = "iPhone 13", Availability = true },
            new Equipment { Id = 5, Type = "Laptop", Description = "HP EliteBook", Availability = false },
            new Equipment { Id = 6, Type = "Tablet", Description = "Samsung Galaxy Tab", Availability = true },
            new Equipment { Id = 7, Type = "Another", Description = "Projector", Availability = true },
            new Equipment { Id = 8, Type = "Phone", Description = "Google Pixel", Availability = false }
        };

        public static IEnumerable<Equipment> GetAllEquipment()
        {
            return _equipment;
        }

        public static IEnumerable<Equipment> GetAvailableEquipment()
        {
            return _equipment.Where(e => e.Availability);
        }
    }
}