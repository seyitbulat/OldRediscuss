using Infrastructure.Utilities.ApiResponses;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Interfaces
{
	public interface IUserBs
	{
		 Task<ApiResponse<UserGetDto>> GetByIdAsync(int id);

		 Task<ApiResponse<User>> AddUserAsync(UserPostDto dto);
	}
}
