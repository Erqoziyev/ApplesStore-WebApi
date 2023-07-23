﻿using AppleStore.DataAccess.Utils;
using AppleStore.Service.Dtos.Deliveries;
using AppleStore.Service.Interfaces.Deliveries;
using AppleStore.Service.Validators.Dtos.Deliveries;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.WebApi.Controllers;

[Route("api/deliveries")]
[ApiController]
public class DeliveriesController : ControllerBase
{
    private IDeliveryService _service;
    private readonly int maxPageSize = 30;


    public DeliveriesController(IDeliveryService deliveryService)
    {
        this._service = deliveryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

    [HttpGet("{deliveryId}")]
    public async Task<IActionResult> GetByIdAsync (long deliveryId)
        =>Ok(await _service.GetByIdAsync(deliveryId));  

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] DeliveryCreateDto dto)
    {
        var validator = new DeliveryCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors); 
    }

    [HttpDelete("{deliveryId}")]
    public async Task<IActionResult> DeleteAsync(long deliveryId)
        =>Ok(await _service.DeleteAsync(deliveryId));
}