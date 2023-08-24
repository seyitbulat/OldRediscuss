using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Rediscuss.Model.Dtos.PostImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Business.Interfaces
{
    public interface IPostImageBs
    {
        Task<ApiResponse<List<PostImageGetDto>>> AddPostImageAsync(IFormFileCollection files, int postId);
        Task<ApiResponse<PostImageGetDto>> AddPostImageAsync(PostImageUploadDto uploadDto, int postId);
        Task<ApiResponse<List<PostImageGetDto>>> GetImagesFromPostIdAsync(int postId, params string[] includeList);

        Task<ApiResponse<NoData>> DeleteImages(int postId);
    }
}
