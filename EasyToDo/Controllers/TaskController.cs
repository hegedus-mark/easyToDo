using Microsoft.AspNetCore.Mvc;
using EasyToDo.Services;
namespace EasyToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase

{
    private static List<TaskItem> _tasks = new List<TaskItem>();
    private static int idCounter = 0;
    private Database _db;
    
    public TaskController(Database database)
    {
        _db = database;
    }
    
    [HttpGet ("all")]
    public List<TaskItem> Get()
    {
        return _db.GetTasks();
    }
    
    [HttpPost]
    public int Post(TaskItem task)
    {
        int Id = idCounter + 1;
        idCounter += 1;
        task.Id = Id;
        return _db.InsertTask(task);
    }
    
    [HttpDelete ("{Id}")]
    public void Delete(int Id)
    {
        _db.DeleteTask(Id); 
    }

    [HttpPut("{Id}")]
    public void Update(int Id, TaskItem newTask)
    {
        _db.UpdateTask(Id, newTask);
    }
}