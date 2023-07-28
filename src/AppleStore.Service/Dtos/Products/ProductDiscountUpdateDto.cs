namespace AppleStore.Service.Dtos.Products;

public class ProductDiscountUpdateDto
{
    public long ProductId { get; set; }

    public long DiscountId { get; set; }

    public string Description { get; set; } = string.Empty;

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public short Percentage { get; set; }
}
