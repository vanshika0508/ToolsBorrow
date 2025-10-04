
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolsBorrow.Models
{
    public class BorrowRequest
    {
        [Key]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in format: xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        [StringLength(20)]
        public string Role { get; set; } = string.Empty;

        // Foreign key to Equipment
        public int EquipmentId { get; set; }

        // Navigation property
        [ForeignKey("EquipmentId")]
        public virtual Equipment? Equipment { get; set; }

        [Required(ErrorMessage = "Request details are required")]
        [StringLength(500)]
        public string RequestDetails { get; set; } = string.Empty;

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Duration must be greater than 0")]
        public int Duration { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}