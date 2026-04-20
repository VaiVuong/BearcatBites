namespace BearcatBites.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Restaurant { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public ItemType Type { get; set; }
    }

    public enum ItemType
    {
        Bite,
        Sip
    }
}
