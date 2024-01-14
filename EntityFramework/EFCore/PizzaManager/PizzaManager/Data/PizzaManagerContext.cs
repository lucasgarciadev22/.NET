using Microsoft.EntityFrameworkCore;
using PizzaManager.Models;

namespace PizzaManager.Data;

public class PizzaManagerContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Database=Pizza-Manager;Integrated Security=false;TrustServerCertificate=true;User ID=local-db;Password=p@ssw0rd;"
        );
}
