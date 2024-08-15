using Az204WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

namespace Az204WebApp.Pages;

public class CustomersModel : PageModel
{
    public IEnumerable<Customer> Customers { get; set; }
    
    private readonly ILogger<IndexModel> _logger;
    private string _getCustomersEndpoint;
    private IHttpClientFactory _httpClientFactory;
    
    public CustomersModel(
        ILogger<IndexModel> logger,
        IConfiguration configuration,
        IHttpClientFactory httpClientFactory
    ) {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _getCustomersEndpoint = $"{configuration.GetValue<string>("JsFunctionAppHost")}/api/get-customers";
    }

    public async Task OnGet()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(_getCustomersEndpoint);
        var content = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        Customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(content);
        Customers ??= new List<Customer>();
    }
}