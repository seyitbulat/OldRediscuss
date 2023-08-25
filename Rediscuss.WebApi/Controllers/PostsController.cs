using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Entities;

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

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var response = await _postBs.GetAllPostsAsync("User","Comments", "PostImages");
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<PostGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var response = await _postBs.GetByIdAsync(id, "User");
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByTitle")]
        public async Task<IActionResult> GetByTitleAsync([FromQuery] string title)
		{
			var response = await _postBs.GetByTitleAsync(title);
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByBody")]
        public async Task<IActionResult> GetByBodyAsync([FromQuery] string body)
		{
			var response = await _postBs.GetByBodyAsync(body);
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByDate")]
        public async Task<IActionResult> GetByDateAsync([FromQuery] int min, [FromQuery] int max)
		{
			var response = await _postBs.GetByDateAsync(min, max);
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getBySubredis")]
        public async Task<IActionResult> GetBySubredis([FromQuery] int subredisId)
		{
			var response = await _postBs.GetBySubredisIdAsync(subredisId, "User", "Comments");
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByJoinedUser")]
        public async Task<IActionResult> GetByJoinedUser([FromQuery] int userId)
		{
			var response = await _postBs.GetByJoinedUsersAsync(userId, "Subredis", "User", "Comments");
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByUser")]
        public async Task<IActionResult> GetByUser([FromQuery] int userId)
		{
			var response = await _postBs.GetByUserIdAsync(userId);
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<PostGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostPostDto dto)
		{
			var response = await _postBs.AddPostAsync(dto);
			return await SendResponse(response);
		}
	}
}
