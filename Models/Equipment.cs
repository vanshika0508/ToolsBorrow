namespace ToolsBorrow.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Availability { get; set; }
    }
}