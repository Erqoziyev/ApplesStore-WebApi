using AppleStore.DataAccess.Utils;
using AppleStore.Service.Dtos.Categories;
using AppleStore.Service.Interfaces.Categories;
using AppleStore.Service.Validators.Dtos.Categories;
using FluentValidation;using Microsoft.AspNetCore.Mvc;

namespace AppleStore.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly int maxPageSize = 30;

    public CategoriesController(ICategoryService service)
    {
        this._service = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
    => Ok(await _service.GetByIdAsync(categoryId));


    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
       => Ok(await _service.CountAsync());


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        var createValidator = new CategoryCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreatAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
    {
        var updateValidator = new CategoryUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(categoryId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
