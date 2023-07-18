using AppleStore.Domain.Enums;

namespace AppleStore.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }

    public long DeliveryId { get; set; }

    public OrderStatus Status { get; set; }

    public double ProductPrice { get; set; }

    public double DeliveryPrice { get; set; }

    public double ResultPrice { get; set; }

    public double Latitude { get; set; }

    public double Longtitude { get; set; }

    public PaymentType Payment { get; set; }

    public bool IsPaid { get; set; }

    public bool IsContracted { get; set; }

    public string Description { get; set; } = string.Empty;
}
