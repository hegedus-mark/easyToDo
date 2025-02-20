// using System.Data;
// using Npgsql;
// using EasyToDo.Models;

// namespace EasyToDo.Services;

// public class Database
// {
//     private string _connectionString;

//     public Database(IConfiguration configuration)
//     {
//         _connectionString = configuration.GetConnectionString("DefaultConnection");
//     }

//     public List<TaskItem> GetTasks()
//     {
//         List<TaskItem> tasks = new List<TaskItem>();

//         using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
//         connection.Open();

//         const string query = "SELECT * FROM tasks";
//         NpgsqlCommand command = new NpgsqlCommand(query, connection);
//         NpgsqlDataReader reader = command.ExecuteReader();
        
//         while (reader.Read())
//         {
//             tasks.Add(new TaskItem
//             {
//                 Id = reader.GetInt32("Id"),
//                 Name = reader.GetString("Name"),
//                 Description  = reader.GetString("Description"),
//                 Status = reader.GetString("Status"),
//                 Date = reader.GetDateTime("Date")
//             });
//         }
//         return tasks;
//     }

//     public int InsertTask(TaskItem task)
//     {
//          using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
//          connection.Open();

//          const string query = "INSERT INTO tasks (id, name, description, status, date) VALUES (@Id, @Name, @Description, @Status, @Date)";
//          NpgsqlCommand command = new NpgsqlCommand(query, connection);

//          command.Parameters.AddWithValue("@Id", task.Id);
//          command.Parameters.AddWithValue("@Name", task.Name);
//          command.Parameters.AddWithValue("@Description", task.Description);
//          command.Parameters.AddWithValue("@Status", task.Status);
//          command.Parameters.AddWithValue("@Date", task.Date);

//          return Convert.ToInt32(command.ExecuteScalar());
//     }
    
//     public void DeleteTask(int Id) 
//     {
//          using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
//          connection.Open();

//          const string query = "DELETE FROM tasks WHERE id = @Id";
//          NpgsqlCommand command = new NpgsqlCommand(query, connection);
//          command.Parameters.AddWithValue("@Id", Id);
//          command.ExecuteNonQuery();

//     }

//     public void UpdateTask(int Id, TaskItem task)
//     {
//         using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
//         connection.Open();

//         const string query =
//             "UPDATE tasks SET id = @Id, name = @Name, description = @Description, status = @Status, date = @Date WHERE id = @id";
//         NpgsqlCommand command = new NpgsqlCommand(query, connection);

//         command.Parameters.AddWithValue("@id", Id);
//         command.Parameters.AddWithValue("@Id", task.Id);
//         command.Parameters.AddWithValue("@Name", task.Name);
//         command.Parameters.AddWithValue("@Description", task.Description);
//         command.Parameters.AddWithValue("@Status", task.Status);
//         command.Parameters.AddWithValue("@Date", task.Date);
        
//         command.ExecuteNonQuery();

//     }
// }