using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.JsonPatch;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetByIdAsync(int id, params string[] includeList);
		Task<List<User>> GetAllsAsync(params string[] includeList);
		Task<List<User>> GetUserNamesAsync();
		Task<List<User>> GetEmailAsync();

		Task<User> GetByUserNameAndPassword(string userName, string password);

	}
}
