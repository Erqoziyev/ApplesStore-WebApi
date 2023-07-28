using AppleStore.DataAccess.Utils;
using AppleStore.Service.Dtos.Categories;
using AppleStore.Service.Dtos.Products;
using AppleStore.Service.Interfaces.Categories;
using AppleStore.Service.Interfaces.Products;
using AppleStore.Service.Validators.Dtos.Categories;
using AppleStore.Service.Validators.Dtos.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AppleStore.WebApi.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly int maxPageSize = 30;

    public ProductController(IProductService service)
    {
        this._service = service;
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{productId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long productId)
    => Ok(await _service.GetByIdAsync(productId));


    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
       => Ok(await _service.CountAsync());


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
    {
        var createValidator = new ProductCreateValidator();
        var result = createValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    [HttpPut("{productId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long productId, [FromForm] ProductUpdateDto dto)
    {
        var updateValidator = new ProductUpdateValidator();
        var result = updateValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(productId, dto));
        else return BadRequest(result.Errors);
    }

    [HttpDelete("{productId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long productId)
        => Ok(await _service.DeleteAsync(productId));
}

