using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using System.Security.Claims;

namespace Rediscuss.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : BaseController
	{
		private readonly IUserBs _userBs;
		private readonly IConfiguration _configuration;

		public UsersController(IUserBs userBs, IConfiguration configuration)
		{
			_userBs = userBs;
			_configuration = configuration;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var response = await _userBs.GetByIdAsync(id);
			return await SendResponse(response);
		}

		[HttpGet("login")]
		public async Task<IActionResult> Login([FromQuery] string userName, [FromQuery] string password)
		{
			var response = await _userBs.Login(userName, password);
			
			var claims = new List<Claim>();
			claims.Add(new Claim("userName", response.Data.Username));
			claims.Add(new Claim("userId", response.Data.UserId.ToString()));
			claims.Add(new Claim(ClaimTypes.Role, UserRoles.User));

			var accessToken = new JwtGenerator(_configuration).CreateAccessToken(claims);

			var resultData = new
			{
				Data = response.Data,
				ErrorMessages = response.ErrorMessages,
				StatusCode = response.StatusCode,
				Token = accessToken.Token
			};

			var result = new ObjectResult(resultData);
			return  result;
		}

		[HttpPost]
		public async Task<IActionResult> AddUserAsync([FromBody] UserPostDto dto)
		{
			var response = await _userBs.AddUserAsync(dto);
			return CreatedAtAction(nameof(GetByIdAsync), new { id = response.Data.UserId }, response.Data);
		}

		[Authorize(Roles = UserRoles.Admin)]
		[HttpDelete]
		public async Task<IActionResult> DeleteUserAsync([FromQuery] int id)
		{
			var response = await _userBs.DeleteUserAsync(id);
			return await SendResponse(response);
		}
	}
}
