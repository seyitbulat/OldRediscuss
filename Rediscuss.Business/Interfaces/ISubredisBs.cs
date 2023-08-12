using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Interfaces
{
	public interface ISubredisBs
	{
		Task<ApiResponse<SubredisGetDto>> GetByIdAsync(int id, params string[] includeList);
		Task<ApiResponse<List<SubredisGetDto>>> GetAllAsync();
		Task<ApiResponse<List<SubredisGetDto>>> GetByNameAsync(string name, params string[] includeList);
		Task<ApiResponse<List<SubredisGetDto>>> GetByDescriptionAsync(string description, params string[] includeList);
		Task<ApiResponse<List<SubredisGetDto>>> GetByJoinedUsers(int subredisId, params string[] includeList);

		Task<ApiResponse<Subredis>> AddSubredisAsync(SubredisPostDto dto);
		Task<ApiResponse<NoData>> DeleteSubredisAsync(int id);
	}
}
