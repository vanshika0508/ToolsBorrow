
using System.ComponentModel.DataAnnotations;

namespace EquipmentApp.Models
{
    public class EquipmentRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone is required")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone must be in format xxx-xxx-xxxx")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = "";

        [Required(ErrorMessage = "Equipment type is required")]
        public string Equipment { get; set; } = "";

        public string Details { get; set; } = "";

        [Range(1, 30, ErrorMessage = "Duration must be at least 1 day and max 30 days")]
        public int Duration { get; set; }

        public string Status { get; set; } = "Pending"; // Default status
    }
}

