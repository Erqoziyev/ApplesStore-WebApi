﻿using Microsoft.AspNetCore.Http;

namespace AppleStore.Service.Dtos.Categories; 

public class CategoryUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile? Image { get; set; }
}
