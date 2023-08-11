using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetByIdAsync(int id);
		Task<List<User>> GetUserNamesAsync();
		Task<List<User>> GetEmailAsync();
	}
}
