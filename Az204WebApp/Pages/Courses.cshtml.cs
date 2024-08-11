using Az204WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Az204WebApp.Pages;

public class CouresModel : PageModel
{
    public List<Course> Courses=new List<Course>();
    private readonly ILogger<IndexModel> _logger;
    private IConfiguration _configuration;
    public CouresModel(ILogger<IndexModel> logger,IConfiguration configuration)
    {
        _logger = logger;
        _configuration=configuration;
    }

    public void OnGet()
    {
       
        string connectionString = _configuration.GetConnectionString("Az204SqlDb")!;
        var sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        var sqlcommand = new SqlCommand("SELECT CourseID,CourseName,Rating FROM Course;",sqlConnection);
        using (SqlDataReader sqlDatareader = sqlcommand.ExecuteReader())
        {
            while (sqlDatareader.Read())
            {
                Courses.Add(new Course() {CourseId=Int32.Parse(sqlDatareader["CourseID"].ToString()),
                    CourseName=sqlDatareader["CourseName"].ToString(),
                    Rating=Decimal.Parse(sqlDatareader["Rating"].ToString())});
            }
        }
    }
}