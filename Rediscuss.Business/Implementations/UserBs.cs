using AutoMapper;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Business.CustomExceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using NLog;
using FluentValidation;
using Rediscuss.Business.Validators;
using System.ComponentModel.DataAnnotations;
using Rediscuss.Business.FIlters;
using Rediscuss.Business.Validators.DtoValidators;

namespace Rediscuss.Business.Implementations
{
    public class UserBs : IUserBs
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;
		private readonly ILoggerBs _logger;
		private readonly IValidate<UserPostDto, UserValidator> _validator;

		public UserBs(IUserRepository repo, IMapper mapper, ILoggerBs logger, IValidate<UserPostDto, UserValidator> validator)
		{
			_repo = repo;
			_mapper = mapper;
			_logger = logger;
			_validator = validator;
		}

		public async Task<ApiResponse<User>> AddUserAsync(UserPostDto dto)
		{
			var usernames = await _repo.GetUserNamesAsync();
			var emails = await _repo.GetEmailAsync();

			_validator.Valid(dto);
			
			if (usernames.Where(u => u.Username == dto.Username).Count() > 0)
				throw new BadRequestException("This username is already in use");
			if (usernames.Where(u => u.Email == dto.Email).Count() > 0)
				throw new BadRequestException("This email is already in use");


			if (dto != null)
			{
				var user = _mapper.Map<User>(dto);
				user.Discuit = 0;
				user.CreatedAt = DateTime.Now;
				await _repo.InsertAsync(user);
				return ApiResponse<User>.Success(StatusCodes.Status201Created,user);
			}
			throw new BadRequestException("Enter the user information to add");
		}

		public async Task<ApiResponse<NoData>> DeleteUserAsync(int id)
		{
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");

			var user = await _repo.GetByIdAsync(id);
			if(user != null)
			{
				await _repo.DeleteAsync(user);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("User not found");
		}

		public async Task<ApiResponse<List<UserGetDto>>> GetAllUsers(params string[] includeList)
		{
			var users = await _repo.GetAllsAsync();
			if(users != null)
			{
				var dtoList = _mapper.Map<List<UserGetDto>>(users);
				return ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, dtoList);
			}
			throw new NotFoundException("Users not found");
		}

		public async Task<ApiResponse<UserGetDto>> GetByIdAsync(int id, params string[] includeList)
		{
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");
			if (id == null)
				throw new BadRequestException("Enter an id");
			var user = await _repo.GetByIdAsync(id, includeList);
			if (user != null)
			{
				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			_logger.LogInfo($"User with id:{id} could not found");
			throw new NotFoundException("User not found");
		}

		public async Task<ApiResponse<UserGetDto>> Login(string userName, string password)
		{
			userName = userName.Trim();
			if(userName == null || password == null)
				throw new BadRequestException("username or password cannot be null");

			var user = await _repo.GetByUserNameAndPassword(userName, password);
			if(user != null)
			{
				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Username or password was wrong");
		}
	}
}
