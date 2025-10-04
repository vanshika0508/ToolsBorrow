using System.ComponentModel.DataAnnotations;

namespace ToolsBorrow.Models
{
    public class BorrowRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in format: xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; } = string.Empty;

        [Required(ErrorMessage = "Equipment type is required")]
        public string EquipmentType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Request details are required")]
        public string RequestDetails { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int? Duration { get; set; }

        public string Status { get; set; } = "Pending"; // New property for request status
    }
}