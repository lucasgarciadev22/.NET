using Microsoft.EntityFrameworkCore;
using AzChallengeDio.Models;

namespace AzChallengeDio.Context
{
    public class RHContext : DbContext
    {
        public RHContext(DbContextOptions<RHContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
