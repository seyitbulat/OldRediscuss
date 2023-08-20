using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Join;

namespace Rediscuss.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JoinsController : BaseController
	{
		private readonly IJoinBs _joinBs;

		public JoinsController(IJoinBs joinBs)
		{
			_joinBs = joinBs;
		}

		[HttpGet("getByUserId")]
		public async Task<IActionResult> GetByUserIdAsync([FromQuery] int userId)
		{
			var response = await _joinBs.GetByUserIdAsync(userId, "Subredis");
			return await SendResponse(response);
		}

		[HttpGet("getBySubredisId")]
		public async Task<IActionResult> GetBySubredisIdAsync([FromQuery] int subredisId)
		{
			var response = await _joinBs.GetBySubredisIdAsync(subredisId);
			return await SendResponse(response);
		}

		[HttpPost]
		public async Task<IActionResult> AddJoinAsync([FromBody] JoinPostDto dto)
		{
			var response = await _joinBs.AddJoinAsync(dto);
			return await SendResponse(response);
		}

	}
}
