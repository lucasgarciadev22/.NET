using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Context
{
  public class AgendaContext : DbContext
  {
    //passing options to my class and also to base (DbContext Constructor)
    public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
    {

    }

    public DbSet<Contact> Contacts { get; set; }
  }
}