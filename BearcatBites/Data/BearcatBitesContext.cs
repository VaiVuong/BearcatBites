using Microsoft.EntityFrameworkCore;
using BearcatBites.Models;

namespace BearcatBites.Data
{
    public class BearcatBitesContext : DbContext
    {
        public BearcatBitesContext(DbContextOptions<BearcatBitesContext> options) : base(options)
        {
        }

        public DbSet<FoodItem> FoodItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hard-coded test data (seed data)
            modelBuilder.Entity<FoodItem>().HasData(
                new FoodItem
                {
                    Id = 1,
                    Name = "Skyline Cheese Coney",
                    Restaurant = "Skyline Chili",
                    Description = "A Cincinnati classic — a hot dog smothered in Cincinnati-style chili and topped with a mound of shredded cheddar cheese. The perfect blend of savory and cheesy in every bite.",
                    Type = ItemType.Bite,
                    ImagePath = "Screenshot 2026-04-22 220535.png"

                },
                new FoodItem
                {
                    Id = 2,
                    Name = "Goetta Breakfast Sandwich",
                    Restaurant = "Taste of Belgium",
                    Description = "A hearty Cincinnati-born breakfast sandwich featuring crispy goetta (pork and oat sausage), a fried egg, and melted cheese on a fresh-baked Belgian waffle bun.",
                    Type = ItemType.Bite,
                    ImagePath = "Screenshot 2026-04-22 220737.png"
                },
                new FoodItem
                {
                    Id = 3,
                    Name = "Vietnamese Spring Rolls (Gỏi Cuốn)",
                    Restaurant = "Pho Lang Thang",
                    Description = "Fresh rice paper rolls packed with shrimp, vermicelli, crisp lettuce, cucumber, and herbs. Served with a rich house-made peanut dipping sauce.",
                    Type = ItemType.Bite,
                    ImagePath = "Screenshot 2026-04-22 220757.png"
                },
                new FoodItem
                {
                    Id = 4,
                    Name = "Boba Milk Tea",
                    Restaurant = "Tea n Bowl",
                    Description = "Classic Taiwanese brown sugar milk tea loaded with chewy tapioca pearls. Rich, creamy, and just sweet enough — a beloved Cincinnati staple for boba fans.",
                    Type = ItemType.Sip,
                    ImagePath = "Screenshot 2026-04-22 220831.png"
                },
                new FoodItem
                {
                    Id = 5,
                    Name = "Lavender Oat Latte",
                    Restaurant = "Deeper Roots Coffee",
                    Description = "A beautifully balanced espresso drink made with locally sourced espresso, oat milk, and a house-made lavender syrup. Floral, smooth, and perfect any time of day.",
                    Type = ItemType.Sip,
                    ImagePath = "Screenshot 2026-04-22 220852.png"
                },
                new FoodItem
                {
                    Id = 6,
                    Name = "Mango Lassi",
                    Restaurant = "Ambar India Restaurant",
                    Description = "A thick and refreshing Indian yogurt-based drink blended with ripe Alphonso mango, a pinch of cardamom, and a hint of rose water. Cool and tropical in every sip.",
                    Type = ItemType.Sip,
                    ImagePath = "Screenshot 2026-04-22 220912.png"
                }
            );
        }
    }
}
