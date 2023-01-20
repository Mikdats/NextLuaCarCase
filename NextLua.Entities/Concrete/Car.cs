using NextLua.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NextLua.Entities.Concrete;
public class Car : IEntity
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public decimal Payment { get; set; } = 0;
    public string SellerId { get; set; }
    public string? BuyerId { get; set; }
    public string SellerName { get; set; }
    public string? BuyerName { get; set; }
    public Enums.PaymentStatus? PaymentStatus { get; set; }
    public Enums.PurchaseStatus? PurchaseStatus { get; set; }

}