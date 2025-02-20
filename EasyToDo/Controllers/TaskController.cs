using Microsoft.AspNetCore.Mvc;
using EasyToDo.Models;
using EasyToDo.Data;
using Microsoft.EntityFrameworkCore;
namespace EasyToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase

{
    private static List<TaskItem> _tasks = new List<TaskItem>();
    private AppDbContext _database;
    
    public TaskController(AppDbContext database)
    {
        _database = database;
    }
    
    [HttpGet ("all")]
    public List<TaskItem> Get()
    {
        return _database.tasks.ToList();
    }
    
    [HttpPost]
    public void Post(TaskItem task)
    {
        _database.tasks.Add(task);
        _database.SaveChanges();
    }
    
    [HttpDelete ("{Id}")]
    public void Delete(int Id)
    {
        _database.tasks.Where(task => task.id == Id).ExecuteDelete();
    }

    [HttpPut("{Id}")]
    public void Update(int Id, TaskItem newTask)
    {
        _database.tasks.Where(task => task.id == Id).
        ExecuteUpdate(setters => setters.SetProperty(task => task.id, newTask.id)
                                        .SetProperty(task => task.name, newTask.name)
                                        .SetProperty(task => task.description, newTask.description)
                                        .SetProperty(task => task.status, newTask.status)
                                        .SetProperty(task => task.date, newTask.date)
        );
    }
}