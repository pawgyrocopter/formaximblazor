using Domain.DTOs;

namespace BlazorApp1.Data;

public class OrderDto
{
    public string Name { get; set; }
    public int OrderId { get; set; }
    public OrderState OrderState { get; set; }
    public IEnumerable<PizzaDto> Pizzas { get; set; }
}
public enum OrderState
{
    Making,
    Ready
}