using Az204WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Az204WebApp.Pages;

public class StudentsModel : PageModel
{
    public List<Student> Students = new List<Student>();
    private readonly ILogger<IndexModel> _logger;
    private IConfiguration _configuration;
    public StudentsModel(ILogger<IndexModel> logger,IConfiguration configuration)
    {
        _logger = logger;
        _configuration=configuration;
    }

    public void OnGet()
    {
       
        string connectionString = _configuration.GetConnectionString("Az204MysqlContainer")!;
        var connection = new MySqlConnection(connectionString);
        connection.Open();

        var query = "select roll_no, name, admission_date, branch from student";
        
        var command = new MySqlCommand(query,connection);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Students.Add(new Student  {
                    Id = reader["roll_no"].ToString(),
                    Name = reader["name"].ToString(),
                    AdmissionDate = reader["admission_date"].ToString(),
                    Branch= reader["branch"].ToString()
                });
            }
        }
    }
}