using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Dtos.PostImageDto;
using Rediscuss.Model.Entities;
using System.Data;

namespace Rediscuss.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : BaseController
    {
        private readonly IPostImageBs _postImageBs;

        public PostImagesController(IPostImageBs postImageBs)
        {
            _postImageBs = postImageBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<PostImageGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByPostId/{postId}")]
        public async Task<IActionResult> GetByPostIdAsync([FromRoute] int postId)
        {
            var response = await _postImageBs.GetImagesFromPostIdAsync(postId);
            return await SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<PostImageGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> AddPostImageAsync([FromForm]  PostImageUploadDto dto,[FromQuery] int postId)
        {
            var response = await _postImageBs.AddPostImageAsync(dto, postId);
            return await SendResponse(response);
        }

    }
}
