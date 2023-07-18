using System.ComponentModel.DataAnnotations;

namespace AppleStore.Domain.Entities.Deliveries;

public class Delivery : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;
}
