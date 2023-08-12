using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Interfaces
{
	public interface IJoinBs
	{
		Task<ApiResponse<List<JoinGetDto>>> GetByUserIdAsync(int userId, params string[] includeList);
		Task<ApiResponse<List<JoinGetDto>>> GetBySubredisIdAsync(int subredisId, params string[] includeList);

		Task<ApiResponse<Join>> AddJoinAsync(JoinPostDto dto);
		Task<ApiResponse<NoData>> UpdateJoinAsync(JoinPutDto dto);
		Task<ApiResponse<Join>> DeleteJoinAsync(int userId, int subredisId);
	}
}
