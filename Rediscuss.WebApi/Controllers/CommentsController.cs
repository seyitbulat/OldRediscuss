using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Implementations;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Comment;

namespace Rediscuss.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : BaseController
	{
		private readonly ICommentBs _commentBs;

		public CommentsController(ICommentBs commentBs)
		{
			_commentBs = commentBs;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var response = await _commentBs.GetByIdAsync(id);
			return await SendResponse(response);
		}

		[HttpGet("getByPostId")]
		public async Task<IActionResult> GetByPostIdAsync([FromQuery] int postId)
		{
			var response = await _commentBs.GetByPostIdAsync(postId);
			return await SendResponse(response);
		}

		[HttpPost]
		public async Task<IActionResult> GetByBodyAsync([FromBody] CommentPostDto dto)
		{
			var response = await _commentBs.AddCommentAsync(dto);
			return await SendResponse(response);
		}
	}
}
