using System.ComponentModel.DataAnnotations;

namespace ToolsBorrow.Models
{
    public enum EquipmentType
    {
        Laptop,
        Phone,
        Tablet,
        Another
    }
    public class Equipment
    {
        public int Id { get; set; }
        [Required]
        public EquipmentType Type { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsAvailable { get; set; } = true;
    }

}