using Microsoft.FeatureManagement;

namespace Az204WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Retrieve the connection string
        string connectionString = builder.Configuration.GetConnectionString("AppConfig");
        
        // Load configuration from Azure App Configuration
        //builder.Configuration.AddAzureAppConfiguration(connectionString);
        builder.Configuration.AddAzureAppConfiguration(options => {
            options.Connect(connectionString);
            options.UseFeatureFlags();  // Load Feature Flags
        });
        
        // bind Azure App Configuration settings to AppSettings model
        builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Settings"));

        
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddHttpClient();
        
        // Add Azure App Configuration middleware to the container of services.
        builder.Services.AddAzureAppConfiguration();

        // Add feature management to the container of services.
        builder.Services.AddFeatureManagement();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}