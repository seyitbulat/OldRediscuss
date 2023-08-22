using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.PostImageDto;

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

        [HttpGet("getByPostId/{postId}")]
        public async Task<IActionResult> GetByPostIdAsync([FromRoute] int postId)
        {
            var response = await _postImageBs.GetImagesFromPostIdAsync(postId);
            return await SendResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddPostImageAsync([FromForm]  PostImageUploadDto dto,[FromQuery] int postId)
        {
            var response = await _postImageBs.AddPostImageAsync(dto, postId);
            return await SendResponse(response);
        }

    }
}
