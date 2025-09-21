namespace EquipmentApp.Models
{
    public class EquipmentRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Role { get; set; } = "";
        public string Equipment { get; set; } = "";
        public string Details { get; set; } = "";
        public int Duration { get; set; }
        public string Status { get; set; } = "Pending"; // Default status
    }
}
