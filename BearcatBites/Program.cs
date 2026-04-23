using Microsoft.EntityFrameworkCore;
using BearcatBites.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<BearcatBitesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BearcatBitesContext")));

// Add session support for admin authentication
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed test data on startup if database is empty
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BearcatBitesContext>();
    context.Database.EnsureCreated();

    if (!context.FoodItems.Any())
    {
        context.FoodItems.AddRange(
            new BearcatBites.Models.FoodItem
            {
                Name = "Skyline Cheese Coney",
                Restaurant = "Skyline Chili",
                Description = "A Cincinnati classic — a hot dog smothered in Cincinnati-style chili and topped with a mound of shredded cheddar cheese. The perfect blend of savory and cheesy in every bite.",
                Type = BearcatBites.Models.ItemType.Bite
            },
            new BearcatBites.Models.FoodItem
            {
                Name = "Goetta Breakfast Sandwich",
                Restaurant = "Taste of Belgium",
                Description = "A hearty Cincinnati-born breakfast sandwich featuring crispy goetta (pork and oat sausage), a fried egg, and melted cheese on a fresh-baked Belgian waffle bun.",
                Type = BearcatBites.Models.ItemType.Bite
            },
            new BearcatBites.Models.FoodItem
            {
                Name = "Vietnamese Spring Rolls",
                Restaurant = "Pho Lang Thang",
                Description = "Fresh rice paper rolls packed with shrimp, vermicelli, crisp lettuce, cucumber, and herbs. Served with a rich house-made peanut dipping sauce.",
                Type = BearcatBites.Models.ItemType.Bite
            },
            new BearcatBites.Models.FoodItem
            {
                Name = "Boba Milk Tea",
                Restaurant = "Tea n Bowl",
                Description = "Classic Taiwanese brown sugar milk tea loaded with chewy tapioca pearls. Rich, creamy, and just sweet enough — a beloved Cincinnati staple for boba fans.",
                Type = BearcatBites.Models.ItemType.Sip
            },
            new BearcatBites.Models.FoodItem
            {
                Name = "Lavender Oat Latte",
                Restaurant = "Deeper Roots Coffee",
                Description = "A beautifully balanced espresso drink made with locally sourced espresso, oat milk, and a house-made lavender syrup. Floral, smooth, and perfect any time of day.",
                Type = BearcatBites.Models.ItemType.Sip
            },
            new BearcatBites.Models.FoodItem
            {
                Name = "Mango Lassi",
                Restaurant = "Ambar India Restaurant",
                Description = "A thick and refreshing Indian yogurt-based drink blended with ripe Alphonso mango, a pinch of cardamom, and a hint of rose water. Cool and tropical in every sip.",
                Type = BearcatBites.Models.ItemType.Sip
            }
        );
        context.SaveChanges();
    }
}

app.Run();
