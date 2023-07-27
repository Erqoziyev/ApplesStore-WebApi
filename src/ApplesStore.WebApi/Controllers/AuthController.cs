using AppleStore.Service.Dtos.Auth;
using AppleStore.Service.Interfaces.Auth;
using AppleStore.Service.Validators;
using AppleStore.Service.Validators.Dtos.Auth;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("register")]
    [AllowAnonymous]
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

    [HttpPost("register/send-code")]
    [AllowAnonymous]
    public async Task<IActionResult> SendCodeRegisterAsync(string phone)
    {
        var result = PhoneNumberValidator.IsValid(phone);
        if (result == false) return BadRequest("Phone number is invalid!");

        var serviceResult = await _service.SendCodeForRegisterAsync(phone);
        return Ok(new {serviceResult.Result, serviceResult.CachedVerificationMinutes});
    }


    [HttpPost("register/verify")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyRegisterAsync([FromBody] VerifyRegisterDto verifyRegisterDto)
    {
        var serviceResult = await _service.VerifyRegisterAsync(verifyRegisterDto.PhoneNumber, verifyRegisterDto.Code);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
    {
        var validator = new LoginValidator();
        var valResult = validator.Validate(loginDto);
        if (valResult.IsValid == false) return BadRequest(valResult.Errors);

        var serviceResult = await _service.LoginAsync(loginDto);
        return Ok(new { serviceResult.Result, serviceResult.Token });
    }

}
