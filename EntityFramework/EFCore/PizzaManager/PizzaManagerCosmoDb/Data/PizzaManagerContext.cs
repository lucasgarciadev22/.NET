using Microsoft.EntityFrameworkCore;
using PizzaManagerCosmoDb.Models;

namespace PizzaManagerCosmoDb.Data;

public class PizzaManagerContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseCosmos("MyCosmosConnection", "MyCosmosDb");
}
