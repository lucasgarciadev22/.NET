using Microsoft.EntityFrameworkCore;
using TaskAgendaWithEntity.Models;

namespace TaskAgendaWithEntity.Context
{
  public class TaskAgendaContext : DbContext
  {
    public TaskAgendaContext(DbContextOptions<TaskAgendaContext> options) : base(options)
    {

    }

    public DbSet<TaskModel> Tasks { get; set; }
  }
}