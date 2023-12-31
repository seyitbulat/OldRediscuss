﻿using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class UserRepository : BaseRepository<User, RediscussContext>, IUserRepository
	{
		public async Task<User> GetByIdAsync(int id, params string[] includeList)
		{
			return await GetAsync(u => u.UserId == id, includeList);
		}
		
		public async Task<List<User>> GetUserNamesAsync()
		{
			return await GetColumnAsync(u => new User { Username = u.Username });
		}

		public async Task<List<User>> GetEmailAsync()
		{
			return await GetColumnAsync(u => new User { Email = u.Email});
		}

		public async Task<List<User>> GetAllsAsync(params string[] includeList)
		{
			return await GetAllAsync(includeList: includeList);
		}

		public async Task<User> GetByUserNameAndPassword(string userName, string password)
		{
			return await GetAsync(u => u.Username == userName && u.Password == password);
		}
	}
}
