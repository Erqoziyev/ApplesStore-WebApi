using AppleStore.DataAccess.Utils;
using AppleStore.Domain.Entities.Products;
using AppleStore.Service.Dtos.Deliveries;
using AppleStore.Service.Dtos.Products;
using AppleStore.Service.Interfaces.ProductDiscounts;
using AppleStore.Service.Validators.Dtos.Deliveries;
using AppleStore.Service.Validators.Dtos.ProductDiscounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AppleStore.WebApi.Controllers;

[Route("api/productDiscount")]
[ApiController]
public class ProductDiscountController : ControllerBase
{
    private IProductDiscountService _service;
    private readonly int maxPageSize = 30;

    public ProductDiscountController(IProductDiscountService service)
    {
        this._service = service;
    }

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
       => Ok(await _service.CountAsync());


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));


    [HttpGet("{productDiscountId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long productDiscountId)
        => Ok(await _service.GetByIdAsync(productDiscountId));


    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] ProductDiscountCreateDto dto)
    {
        var validator = new ProductDiscountCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }


    [HttpPut("{productDiscountId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long productDiscountId, [FromForm] ProductDiscountUpdateDto dto)
    {
        var validator = new ProductDiscountUpdateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.UpdateAsync(productDiscountId, dto));
        else return BadRequest(result.Errors);
    }


    [HttpDelete("{productDiscount}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long productDiscountId)
        => Ok(await _service.DeleteAsync(productDiscountId));
}
