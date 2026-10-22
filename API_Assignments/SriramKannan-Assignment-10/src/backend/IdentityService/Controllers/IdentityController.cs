using EduSphere.IdentityService.Models;
using EduSphere.IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduSphere.IdentityService.Controllers;

[ApiController]
[Route("identity")]
public sealed class IdentityController(IIdentityService service) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken ct)
    {
        try { 
            return Ok(await service.RegisterAsync(request, ct)); 
        }
        catch (ArgumentException ex) { 
            return BadRequest(new { message = ex.Message }); 
        }
        catch (InvalidOperationException ex) {
            return Conflict(new { message = ex.Message }); 
        }
        catch (Exception) { 
            return StatusCode(500, new { message = "Registration failed." });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken ct)
    {
        try { 
            return Ok(await service.LoginAsync(request, ct));
        }
        catch (UnauthorizedAccessException ex) { 
            return Unauthorized(new { message = ex.Message }); 
        }
        catch (Exception) { 
            return StatusCode(500, new { message = "Login failed." }); 
        }
    }
}
