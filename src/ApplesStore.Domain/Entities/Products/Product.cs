using System.ComponentModel.DataAnnotations;

namespace AppleStore.Domain.Entities.Products;

public class Product : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public double Price { get; set; }

    public long CategoryId { get; set; }
}
