using Microsoft.AspNetCore.Http;

namespace AppleStore.Service.Dtos.Media;
public class AvatarCreateDto
{
    public IFormFile Avatar { get; set; } = default!;
}