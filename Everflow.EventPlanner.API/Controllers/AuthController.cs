using Everflow.EventPlanner.Application.Features.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Everflow.EventPlanner.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<EventController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<EventController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<AuthResult>> GetToken([FromBody] AuthRequest request)
        {
            var result = await _authService.AuthLogin(request.EmailAddress, request.Password);
            return Ok(result);
        }

    }
}
