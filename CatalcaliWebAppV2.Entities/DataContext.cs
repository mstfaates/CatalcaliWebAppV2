using System.Data.Entity;


namespace CatalcaliWebAppV2.Entities
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
    }
}
