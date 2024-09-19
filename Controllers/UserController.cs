using Microsoft.AspNetCore.Mvc;

[Route("api/user/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // Registeration
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        var result = await _userService.CreateUserAsync(user);
        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        }

        return Ok(user);
    }

    // Login
    // TODO
}
