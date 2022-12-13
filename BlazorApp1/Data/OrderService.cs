using System.Text;
using System.Text.Json;

namespace BlazorApp1.Data;

public class OrderService
{
    private  HttpClient _client;
    private IHttpClientFactory _clientFactory;
    public OrderService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
        _client = clientFactory.CreateClient();
    }
    
    public async Task<IEnumerable<OrderDto>> GetAllOrders(string token)
    {
        _client = _clientFactory.CreateClient();
        _client.DefaultRequestHeaders.Add("Authorization","Bearer " + token);
        var response =  _client.GetStringAsync("https://localhost:7222/api/order").Result;
        var a = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<OrderDto>>(response, new JsonSerializerOptions 
        {
            PropertyNameCaseInsensitive = true
        });
        return a ;
    }
}