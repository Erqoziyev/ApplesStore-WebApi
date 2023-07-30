using Microsoft.AspNetCore.Http;

namespace AppleStore.Service.Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string PassportSeria { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public string Region { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }
}
