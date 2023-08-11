using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class UserRepository : BaseRepository<User, RediscussContext>, IUserRepository
	{
		public async Task<User> GetByIdAsync(int id)
		{
			return await GetAsync(u => u.UserId == id);
		}
		
		public async Task<List<User>> GetUserNamesAsync()
		{
			return await GetColumnAsync(u => new User { Username = u.Username });
		}

		public async Task<List<User>> GetEmailAsync()
		{
			return await GetColumnAsync(u => new User { Email = u.Email});
		}
	}
}
