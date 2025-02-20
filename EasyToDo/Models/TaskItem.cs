namespace EasyToDo.Models;

public class TaskItem
{
    public int id { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required string status { get; set; }
    public DateTime date { get; set; }
    
}
