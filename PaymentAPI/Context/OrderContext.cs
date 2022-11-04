using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Context
{
  #pragma warning disable CS1591
  public class OrderContext : DbContext
  {
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {

    }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<OrderRegistry> OrderRegistries { get; set; }
  }
  #pragma warning restore CS1591
}