namespace HomeWorkToDoList.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }

        public DateOnly Date { get; set; } 

        public string? Note { get; set; }
    }
}
