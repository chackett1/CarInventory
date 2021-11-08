using System.Data.Entity;
namespace CarInventory.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("CarInventory")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}