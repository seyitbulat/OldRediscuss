using AutoMapper;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Business.CustomExceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using NLog;

namespace Rediscuss.Business.Implementations
{
	public class UserBs : IUserBs
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;
		private readonly ILoggerBs _logger;

		public UserBs(IUserRepository repo, IMapper mapper, ILoggerBs logger)
		{
			_repo = repo;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<ApiResponse<User>> AddUserAsync(UserPostDto dto)
		{
			var usernames = await _repo.GetUserNamesAsync();
			var emails = await _repo.GetEmailAsync();

			if (usernames.Where(u => u.Username == dto.Username).Count() > 0)
				throw new BadRequesException("This username is already in use");
			if (usernames.Where(u => u.Email == dto.Email).Count() > 0)
				throw new BadRequesException("This email is already in use");
			if (dto.Username.Length < 3)
				throw new BadRequesException("The username cannot be less than 3 characters");


			if (dto != null)
			{
				var user = _mapper.Map<User>(dto);
				user.Discuit = 0;
				user.CreatedAt = DateTime.Now;
				await _repo.InsertAsync(user);
				return ApiResponse<User>.Success(StatusCodes.Status201Created,user);
			}
			throw new BadRequesException("Enter the user information to add");
		}

		public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int id)
		{
			if (id < 0)
				throw new BadRequesException("Id cannot be negative");
			if (id == null)
				throw new BadRequesException("Enter an id");
			var user = await _repo.GetByIdAsync(id);
			if (user != null)
			{
				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			_logger.LogInfo($"User with id:{id} could not found");
			throw new NotFoundException("User not found");
		}
	}
}
