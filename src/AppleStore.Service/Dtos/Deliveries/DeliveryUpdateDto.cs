using Microsoft.AspNetCore.Http;

namespace AppleStore.Service.Dtos.Deliveries;

public class DeliveryUpdateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public string Region { get; set; } = string.Empty;

    public IFormFile? Avatar { get; set; }
}
