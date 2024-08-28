using Newtonsoft.Json;

namespace Az204WebApp.Models;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string AdmissionDate { get; set; }
    public string Branch { get; set; }
    public string Status { get; set; }
    public decimal Percentage { get; set; }
}