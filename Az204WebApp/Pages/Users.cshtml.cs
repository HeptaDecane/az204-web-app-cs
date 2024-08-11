using Az204WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Az204WebApp.Pages;

public class UsersModel : PageModel
{
    public IEnumerable<User> Users { get; set; }
    
    private readonly ILogger<IndexModel> _logger;
    private string _userBase;
    private IHttpClientFactory _httpClientFactory;
    
    public UsersModel(
        ILogger<IndexModel> logger,
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory
    ) {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _userBase = $"{configuration.GetValue<string>("JsonDb")}/users.json";
    }

    public async Task OnGet()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(_userBase);
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        Users = JsonConvert.DeserializeObject<IEnumerable<User>>(content);
        Users ??= new List<User>();
    }
}