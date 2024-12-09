using BookStore.BL.Auth;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Service.Controllers;

public class AuthController(IAuthProvider authProvider) : ControllerBase
{
    [HttpGet]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromQuery] string login, [FromQuery] string password)
    {
        try
        {
            var tokens = await authProvider.AuthorizeUser(login, password);
            return Ok(tokens);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(string login, string password)
    {
        try
        {
            var user = await authProvider.RegisterUser(login, password);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}