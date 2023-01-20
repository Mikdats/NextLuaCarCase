using NextLua.Core.Entities;

namespace NextLua.Entities.DTOs;

public class SoldCarDto :IDto
{
    public string SellerName { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
}