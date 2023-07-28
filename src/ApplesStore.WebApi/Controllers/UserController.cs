using AppleStore.DataAccess.Utils;
using AppleStore.Service.Dtos.Users;
using AppleStore.Service.Interfaces.Users;
using AppleStore.Service.Validators.Dtos.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppleStore.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly int maxPageSize = 30;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        {
            return Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(long userId)
        {
            return Ok(await _userService.GetByIdAsync(userId));

        }

        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
        {
            return Ok(await _userService.CountAsync());
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateAsync(long userId, [FromForm] UserUpdateDto userUpdateDto)
        {
            var updateValidator = new UserUpdateValidator();
            var vrResult = updateValidator.Validate(userUpdateDto);
            if (vrResult.IsValid) return Ok(await _userService.UpdateAsync(userId, userUpdateDto));
            else return BadRequest(vrResult.Errors);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteAsync(long userId)
        {
            return Ok(await _userService.DeleteAsync(userId));
        }
    }
}
