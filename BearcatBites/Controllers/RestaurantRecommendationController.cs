using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BearcatBites.Data;
using BearcatBites.Models;

namespace BearcatBites.Controllers
{
    public class RestaurantRecommendationController : Controller
    {
        private readonly ILogger<RestaurantRecommendationController> _logger;
        private readonly BearcatBitesContext _context;

        public RestaurantRecommendationController(ILogger<RestaurantRecommendationController> logger, BearcatBitesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> ExploreBites()
        {
            var bites = await _context.FoodItems.Where(f => f.Type == ItemType.Bite).ToListAsync();
            return View(bites);
        }

        public async Task<IActionResult> ExploreSips()
        {
            var sips = await _context.FoodItems.Where(f => f.Type == ItemType.Sip).ToListAsync();
            return View(sips);
        }
    }
}
