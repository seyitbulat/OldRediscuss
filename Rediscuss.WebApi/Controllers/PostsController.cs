using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;

namespace Rediscuss.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostsController : BaseController
	{
		private readonly IPostBs _postBs;

		public PostsController(IPostBs postBs)
		{
			_postBs = postBs;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var response = await _postBs.GetByIdAsync(id);
			return await SendResponse(response);
		}

		[HttpGet("getByTitle")]
		public async Task<IActionResult> GetByTitleAsync([FromQuery] string title)
		{
			var response = await _postBs.GetByTitleAsync(title);
			return await SendResponse(response);
		}

		[HttpGet("getByBody")]
		public async Task<IActionResult> GetByBodyAsync([FromQuery] string body)
		{
			var response = await _postBs.GetByBodyAsync(body);
			return await SendResponse(response);
		}

		[HttpGet("getByDate")]
		public async Task<IActionResult> GetByDateAsync([FromQuery] int min, [FromQuery] int max)
		{
			var response = await _postBs.GetByDateAsync(min, max);
			return await SendResponse(response);
		}

		[HttpGet("getBySubredis")]
		public async Task<IActionResult> GetBySubredis([FromQuery] int subredisId)
		{
			var response = await _postBs.GetBySubredisIdAsync(subredisId);
			return await SendResponse(response);
		}
	}
}
