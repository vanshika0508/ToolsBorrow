using ToolsBorrow.Models;

namespace ToolsBorrow.Data
{
    public static class SeedData
    {
        public static void Initialize(FastEquipmentContext context)
        {
            if (!context.Equipment.Any())
            {
                context.Equipment.AddRange(
                    new Equipment { Type = EquipmentType.Laptop, Description = "Dell XPS 13 - Lightweight and powerful laptop for development work", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Laptop, Description = "MacBook Pro 16-inch - High-performance laptop for design and development", IsAvailable = false },
                    new Equipment { Type = EquipmentType.Phone, Description = "iPhone 14 - Latest model with excellent camera and performance", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Phone, Description = "Samsung Galaxy S23 - Android phone with great display and battery life", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Tablet, Description = "iPad Air - Perfect for note-taking and presentations", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Tablet, Description = "Microsoft Surface Pro - Versatile 2-in-1 tablet laptop", IsAvailable = false },
                    new Equipment { Type = EquipmentType.Another, Description = "Noise-cancelling headphones - Sony WH-1000XM4", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Another, Description = "Portable projector - Epson EX3260 for presentations", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Laptop, Description = "Lenovo ThinkPad - Durable business laptop with great keyboard", IsAvailable = true },
                    new Equipment { Type = EquipmentType.Phone, Description = "Google Pixel 7 - Excellent camera and pure Android experience", IsAvailable = false }
                );
                context.SaveChanges();
            }
        }
    }
}