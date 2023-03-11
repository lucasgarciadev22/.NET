namespace TaskAgendaWithEntity.Models
{
  public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TaskStatus Status { get; set; }
    }
}