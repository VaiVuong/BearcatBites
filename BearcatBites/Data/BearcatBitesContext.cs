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
    }
}
