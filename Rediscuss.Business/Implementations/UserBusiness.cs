using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Business.Implementations
{
	public class UserBusiness : IUserBusiness
	{
		public Task<User> CreateUserAsync(UserPostDto dto)
		{
			throw new NotImplementedException();
		}

		public Task<UserGetDto> GetByIdAsync(int id)
		{
			
		}
	}
}
