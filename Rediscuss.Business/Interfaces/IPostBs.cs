using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.Post;

namespace Rediscuss.Business.Interfaces
{
	public interface IPostBs
	{
		Task<ApiResponse<PostGetDto>> GetByIdAsync(int id);
		Task<ApiResponse<List<PostGetDto>>> GetByTitleAsync(string title);
		Task<ApiResponse<List<PostGetDto>>> GetByBodyAsync(string body);
		Task<ApiResponse<List<PostGetDto>>> GetByDateAsync(int min, int max);
		Task<ApiResponse<List<PostGetDto>>> GetBySubredisIdAsync(int subredisId);
	}
}
