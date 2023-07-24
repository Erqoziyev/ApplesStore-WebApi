using AppleStore.Service.Dtos.Auth;
using AppleStore.Service.Interfaces.Auth;
using AppleStore.Service.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.WebApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private IAuthService _service;

    public AuthController(IAuthService authService)
    {
        this._service = authService;
    }

    [HttpPost("{register}")]
    public async Task<IActionResult> RegisterAsync([FromForm] RegistorDto registorDto)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(registorDto);
        if (result.IsValid)
        {
            var serviceResult = await _service.RegisterAsync(registorDto);
            return Ok(new {serviceResult.Result, serviceResult.CachedMinutes});
        }
        else return BadRequest(result.Errors);
    }
}
