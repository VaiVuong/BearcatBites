using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BearcatBites.Data;
using BearcatBites.Models;

namespace BearcatBites.Controllers
{
    public class AdminController : Controller
    {
        private readonly BearcatBitesContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(BearcatBitesContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Login()
        {
            if (IsAdminAuthenticated())
            {
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction(nameof(Dashboard));
            }

            ViewBag.Error = "Invalid credentials";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Dashboard()
        {
            if (!IsAdminAuthenticated())
            {
                return RedirectToAction(nameof(Login));
            }
            return View();
        }

        public async Task<IActionResult> ManageEntries()
        {
            if (!IsAdminAuthenticated())
            {
                return RedirectToAction(nameof(Login));
            }

            var items = await _context.FoodItems.OrderByDescending(f => f.Id).ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            if (!IsAdminAuthenticated())
            {
                return RedirectToAction(nameof(Login));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodItem item, IFormFile? imageFile)
        {
            if (!IsAdminAuthenticated())
            {
                return RedirectToAction(nameof(Login));
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_environment.WebRootPath, "images", "items");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    item.ImagePath = "/images/items/" + uniqueFileName;
                }

                _context.FoodItems.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ManageEntries));
            }

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!IsAdminAuthenticated())
            {
                return RedirectToAction(nameof(Login));
            }

            var item = await _context.FoodItems.FindAsync(id);
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.ImagePath))
                {
                    var imagePath = Path.Combine(_environment.WebRootPath, item.ImagePath.TrimStart('/'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.FoodItems.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManageEntries));
        }

        private bool IsAdminAuthenticated()
        {
            return HttpContext.Session.GetString("IsAdmin") == "true";
        }
    }
}
