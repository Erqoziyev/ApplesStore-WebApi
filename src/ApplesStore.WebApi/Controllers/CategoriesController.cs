using AppleStore.Domain.Entities.Categories;
using AppleStore.Service.Dtos.Categories;
using AppleStore.Service.Interfaces.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
       => Ok(await _service.CountAsync());


    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
    => Ok();


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _service.CreatAsync(dto));



    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
