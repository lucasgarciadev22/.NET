using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVC.Context
{
  public class AgendaContext : DbContext
  {
    public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
    {
        
    }

    public DbSet<Contact> Contacts { get; set; }
  }
}