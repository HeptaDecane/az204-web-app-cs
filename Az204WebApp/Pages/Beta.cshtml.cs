using Az204WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Az204WebApp.Pages;

public class BetaModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly AppSettings _appSettings;
    
    public BetaModel(
        ILogger<IndexModel> logger,
        IOptions<AppSettings> options
    ) {
        _logger = logger;
        _appSettings = options.Value;
    }

    public void OnGet() { }
}