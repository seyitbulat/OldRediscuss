using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Interfaces
{
	public interface IUserBusiness
	{
		 Task<UserGetDto> GetByIdAsync(int id);

		 Task<User> CreateUserAsync(UserPostDto dto);
	}
}
