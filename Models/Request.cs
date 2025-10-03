using System.ComponentModel.DataAnnotations;

namespace ToolsBorrow.Models
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Denied
    }
    public enum UserRole
    {
        Student,
        Professor
    }
    public class Request
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in format xxx-xxx-xxxx.")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public int DurationDays { get; set; }

        [Required]
        public int EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

          
    }
    
}