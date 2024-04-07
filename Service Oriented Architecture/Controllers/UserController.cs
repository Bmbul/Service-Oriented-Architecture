using Microsoft.AspNetCore.Mvc;
using SOA.Dtos;
using SOA.Common.Models;
using SOA.Services.Interfaces;

namespace SOA.Controllers;

[ApiController]
[Route("v1/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _userService.CreateAsync(request.firstName, request.lastName);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser([FromQuery] int userId)
    {
        await _userService.DeleteAsync(userId);
        return Ok();
    }


    [HttpGet]
    public async Task<ActionResult<PagedResult<UserDto>>> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        var users = await _userService.GetAllUsersAsync(skip, take);

        return Ok(users);
    }
}