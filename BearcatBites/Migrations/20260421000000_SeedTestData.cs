using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace BearcatBites.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Description", "ImagePath", "Name", "Restaurant", "Type" },
                values: new object[,]
                {
                    { 1, "A Cincinnati classic — a hot dog smothered in Cincinnati-style chili and topped with a mound of shredded cheddar cheese. The perfect blend of savory and cheesy in every bite.", null, "Skyline Cheese Coney", "Skyline Chili", 0 },
                    { 2, "A hearty Cincinnati-born breakfast sandwich featuring crispy goetta (pork and oat sausage), a fried egg, and melted cheese on a fresh-baked Belgian waffle bun.", null, "Goetta Breakfast Sandwich", "Taste of Belgium", 0 },
                    { 3, "Fresh rice paper rolls packed with shrimp, vermicelli, crisp lettuce, cucumber, and herbs. Served with a rich house-made peanut dipping sauce.", null, "Vietnamese Spring Rolls (Gỏi Cuốn)", "Pho Lang Thang", 0 },
                    { 4, "Classic Taiwanese brown sugar milk tea loaded with chewy tapioca pearls. Rich, creamy, and just sweet enough — a beloved Cincinnati staple for boba fans.", null, "Boba Milk Tea", "Tea n Bowl", 1 },
                    { 5, "A beautifully balanced espresso drink made with locally sourced espresso, oat milk, and a house-made lavender syrup. Floral, smooth, and perfect any time of day.", null, "Lavender Oat Latte", "Deeper Roots Coffee", 1 },
                    { 6, "A thick and refreshing Indian yogurt-based drink blended with ripe Alphonso mango, a pinch of cardamom, and a hint of rose water. Cool and tropical in every sip.", null, "Mango Lassi", "Ambar India Restaurant", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6 });
        }
    }
}
