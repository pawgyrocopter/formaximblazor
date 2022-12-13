using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Data;

public class AccountService
{
    private readonly HttpClient _client;
    private LoginDto _loginDto = new LoginDto(){Email = "1", Password = "123123"};
    public AccountService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient();
    }
    
    public async Task<string> Login(LoginDto loginDto)
    {
        
        var loginContent = new StringContent(
            JsonSerializer.Serialize(loginDto),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await (await _client.PostAsync("https://localhost:7222/api/account/login", loginContent)).Content
            .ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<ResponseLogin>(response);
        return token.Token;
    }
    public async Task<string> Login()
    {
        
        var loginContent = new StringContent(
            JsonSerializer.Serialize(this._loginDto),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
        var response = await (await _client.PostAsync("https://localhost:7222/api/account/login", loginContent)).Content
            .ReadAsStringAsync();
        var token = JsonSerializer.Deserialize<ResponseLogin>(response, new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        return token.Token;
    }
}