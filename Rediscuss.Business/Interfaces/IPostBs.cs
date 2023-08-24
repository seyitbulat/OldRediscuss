using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.Post;

namespace Rediscuss.Business.Interfaces
{
	public interface IPostBs
    {
        Task<ApiResponse<PostGetDto>> GetByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<PostGetDto>>> GetByTitleAsync(string title, params string[] includeList);
        Task<ApiResponse<List<PostGetDto>>> GetByBodyAsync(string body, params string[] includeList);
        Task<ApiResponse<List<PostGetDto>>> GetByDateAsync(int min, int max, params string[] includeList);
        Task<ApiResponse<List<PostGetDto>>> GetBySubredisIdAsync(int subredisId, params string[] includeList);
        Task<ApiResponse<List<PostGetDto>>> GetByJoinedUsersAsync(int userId, params string[] includeList);
        Task<ApiResponse<List<PostGetDto>>> GetByUserIdAsync(int userId , params string[] includeList);

		Task<ApiResponse<List<PostGetDto>>> GetAllPostsAsync(params string[] includeList);

		Task<ApiResponse<PostGetDto>> AddPostAsync(PostPostDto dto);
        Task<ApiResponse<NoData>> DeletePostAsync(int postId);
    }
}
