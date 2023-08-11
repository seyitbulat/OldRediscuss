using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.User;

namespace Rediscuss.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : BaseController
	{
		private readonly IUserBs _userBs;

		public UsersController(IUserBs userBs)
		{
			_userBs = userBs;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById([FromRoute] int id)
		{
			var response = await _userBs.GetByIdAsync(id);
			return await SendResponse(response);
		}

		[HttpPost]
		public async Task<IActionResult> InsertUser([FromBody] UserPostDto dto)
		{
			var response = await _userBs.AddUserAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = response.Data.UserId }, response.Data);
		}
	}
}
