using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Interfaces
{
	public interface IUserBs
	{
		Task<ApiResponse<UserGetDto>> GetByIdAsync(int id, params string[] includeList);
		Task<ApiResponse<List<UserGetDto>>> GetAllUsers(params string[] includeList);
		
		
		Task<ApiResponse<UserGetDto>> SignUpAsync(UserSignupDto dto);
        Task<ApiResponse<NoData>> UpdateUserAsync(UserPutDto dto);
		Task<ApiResponse<NoData>> PatchUserAsync(UserPutDto dto);
        Task<ApiResponse<NoData>> DeleteUserAsync(int id);

		Task<ApiResponse<NoData>> ProfileSetupAsync(UserSetUpDto dto);

		Task<ApiResponse<UserGetDto>> LoginAsync(string userName, string password);

		Task<ApiResponse<UserGetDto>> AdminLoginAsync(string userName, string password);

		
	}
}
