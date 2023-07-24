using AppleStore.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AppleStore.Domain.Entities.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public IdentityRole IdentityRole { get; set; }
}
