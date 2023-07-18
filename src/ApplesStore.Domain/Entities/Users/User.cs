using AppleStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AppleStore.Domain.Entities.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public IdentityRole Role { get; set; }
}
