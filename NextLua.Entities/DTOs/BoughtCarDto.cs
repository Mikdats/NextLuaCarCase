using NextLua.Core.Entities;

namespace NextLua.Entities.DTOs;

public class BoughtCarDto :IDto
{
    public string BuyerName { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
}