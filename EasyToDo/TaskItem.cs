namespace EasyToDo;

public class TaskItem
{
    public int? Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
    public DateTime Date { get; set; }
    
}
