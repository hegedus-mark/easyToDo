using Microsoft.AspNetCore.Mvc;

namespace EasyToDo.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase

{
    private static List<TaskItem> _tasks = new List<TaskItem>();
    private static int idCounter = 0;
    
    [HttpGet ("all")]
    public List<TaskItem> Get()
    {
        return _tasks;
    }
    
    [HttpPost]
    public int Post(TaskItem task)
    {
        int Id = idCounter + 1;
        idCounter += 1;
        task.Id = Id;
        _tasks.Add(task);

        return Id;
    }
    
    [HttpDelete ("{Id}")]
    public void Delete(int Id)
    {
        foreach (var task in _tasks)
        {
            if (task.Id == Id)
            {
                _tasks.Remove(task);
                break;
            }
        }
    }
    
    [HttpPut ("{Id}")]
    public void Update(int Id, TaskItem newTask)
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            if (_tasks[i].Id == Id)
            {
                newTask.Id = Id;    
                _tasks[i] = newTask;
                break;
            }
        }
    }
}