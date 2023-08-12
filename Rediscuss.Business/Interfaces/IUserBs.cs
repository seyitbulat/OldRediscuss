using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Interfaces
{
	public interface IUserBs
	{
		Task<ApiResponse<UserGetDto>> GetByIdAsync(int id, params string[] includeList);
		Task<ApiResponse<List<UserGetDto>>> GetAllUsers(params string[] includeList);
		Task<ApiResponse<User>> AddUserAsync(UserPostDto dto);
		Task<ApiResponse<NoData>> DeleteUserAsync(int id);
	}
}
