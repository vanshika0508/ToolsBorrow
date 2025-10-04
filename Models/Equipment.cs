/*namespace ToolsBorrow.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Availability { get; set; }
    }
}*/
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolsBorrow.Models
{
    public class Equipment
    {
        [Key]
        public int EquipmentId { get; set; }

        [Required(ErrorMessage = "Equipment type is required")]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;

        public bool Availability { get; set; } = true;

        // Navigation property for requests
        public virtual ICollection<BorrowRequest>? BorrowRequests { get; set; }
    }
}