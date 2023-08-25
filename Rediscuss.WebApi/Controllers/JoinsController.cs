using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Comment;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Entities;
using System.Data;

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

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<JoinGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByUserId")]
		public async Task<IActionResult> GetByUserIdAsync([FromQuery] int userId)
		{
			var response = await _joinBs.GetByUserIdAsync(userId, "Subredis");
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<JoinGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getBySubredisId")]
        public async Task<IActionResult> GetBySubredisIdAsync([FromQuery] int subredisId)
		{
			var response = await _joinBs.GetBySubredisIdAsync(subredisId);
			return await SendResponse(response);
		}

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<JoinGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddJoinAsync([FromBody] JoinPostDto dto)
		{
			var response = await _joinBs.AddJoinAsync(dto);
			return await SendResponse(response);
		}

	}
}
