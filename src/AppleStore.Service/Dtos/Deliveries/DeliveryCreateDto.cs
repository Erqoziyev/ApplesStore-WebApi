using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AppleStore.Service.Dtos.Deliveries;

public class DeliveryCreateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string PassportSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Region { get; set; } = string.Empty;

    public IFormFile Avatar { get; set; }
}
