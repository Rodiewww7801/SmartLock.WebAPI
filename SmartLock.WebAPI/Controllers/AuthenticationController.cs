using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLock.Auth.DTO;
using SmartLock.Auth.Services;
using System.Linq;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartLock.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthenticationController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpGet("Username")]
		[Authorize(Roles = "Admin")]
		public ActionResult<string?> Username()
		{
			return $"Heelo {User.Claims.First().Value}";
		}

		[AllowAnonymous]
		[HttpPost("Login")]
		public async Task<ActionResult<TokensDTO>> Login(UserDTO userCredentials)
		{
			try
			{
				var sessionDTO = new SessionDTO
				{
					ConnectionId = HttpContext.Connection.Id,
					UserAgent = HttpContext.Request.Headers.UserAgent.ToString(),
					IP = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty,
				};
				var tokensDTO = await _authService.LoginAsync(userCredentials, sessionDTO);
				return tokensDTO;
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[AllowAnonymous]
		[HttpPost("Register")]
		public async Task<ActionResult> Register(UserDTO userCredentials)
		{
			try
			{
				await _authService.RegisterAsync(userCredentials);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
