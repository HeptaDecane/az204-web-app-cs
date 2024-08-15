using Newtonsoft.Json;

namespace Az204WebApp.Models;

public class Customer
{
    [JsonProperty("cust_no")]
    public int Id { get; set; }
    
    [JsonProperty("cust_fname")]
    public string FirstName { private get; set; }
    
    [JsonProperty("cust_lname")]
    public string LastName { private get; set; }

    public string Name => $"{FirstName} {LastName}";
    
    [JsonProperty("cust_company")]
    public string? Company { get; set; }
    
    [JsonProperty("cust_addr")]
    public string Address { get; set; }
    
    [JsonProperty("city")]
    public string City { get; set; }
    
    [JsonProperty("cust_phone")]
    public string Phone { get; set; }
}