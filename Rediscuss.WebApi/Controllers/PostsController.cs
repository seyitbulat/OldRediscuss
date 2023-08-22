using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Entities;

namespace Rediscuss.WebApi.Controllers
{
	[Authorize(Roles = UserRoles.User)]
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
		
		[HttpGet("getByJoinedUser")]
		public async Task<IActionResult> GetByJoinedUser([FromQuery] int userId)
		{
			var response = await _postBs.GetByJoinedUsersAsync(userId, "Subredis", "User");
			return await SendResponse(response);
		}

		[HttpGet("getByUser")]
		public async Task<IActionResult> GetByUser([FromQuery] int userId)
		{
			var response = await _postBs.GetByUserIdAsync(userId);
			return await SendResponse(response);
		}

		[HttpPost]
		public async Task<IActionResult> AddPost([FromBody] PostPostDto dto)
		{
			var response = await _postBs.AddPostAsync(dto);
			return await SendResponse(response);
		}
	}
}
