using AutoMapper;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Business.CustomExceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace Rediscuss.Business.Implementations
{
	public class UserBs : IUserBs
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;

        public UserBs(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
			_mapper = mapper;
        }

        public Task<ApiResponse<User>> AddUserAsync(UserPostDto dto)
		{
			var usernames = _repo.GetUserNamesAsync();
			if (dto == null)
				throw new BadRequesException("Enter the user information to add");
		}

		public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int id)
		{
			if (id < 0)
				throw new BadRequesException("Id cannot be negative");
			if (id == null)
				throw new BadRequesException("Enter an id");
			var user = await _repo.GetByIdAsync(id);
			if(user != null)
			{
				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("User not found");
		}
	}
}
