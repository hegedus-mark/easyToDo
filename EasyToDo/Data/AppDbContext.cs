using Microsoft.EntityFrameworkCore;
using EasyToDo.Models;
namespace EasyToDo.Data;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> tasks { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
     
}
 
    