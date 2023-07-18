namespace AppleStore.Domain.Entities.Orders;

public class OrderDetail : Auditable
{
    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public string Quantity { get; set; } = string.Empty;

    public double TotalPrice { get; set; }

    public double DiscountPrice { get; set; }

    public double ResultPrice { get; set; }
}
