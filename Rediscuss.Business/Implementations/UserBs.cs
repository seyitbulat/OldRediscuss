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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Hosting;

namespace Rediscuss.Business.Implementations
{
    public class UserBs : IUserBs
	{
		private readonly IUserRepository _repo;
		private readonly IMapper _mapper;
		private readonly ILoggerBs _logger;
		private readonly IWebHostEnvironment _webHost;
		private readonly IValidate<UserPostDto, UserValidator> _validator;

        public UserBs(IUserRepository repo, IMapper mapper, ILoggerBs logger, IValidate<UserPostDto, UserValidator> validator, IWebHostEnvironment webHost)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _webHost = webHost;
        }

        public async Task<ApiResponse<UserGetDto>> SignUpAsync(UserSignupDto dto)
		{
			var usernames = await _repo.GetUserNamesAsync();
			var emails = await _repo.GetEmailAsync();

			
			if (usernames.Where(u => u.Username == dto.Username).Count() > 0)
				throw new BadRequestException("This username is already in use");
			if (usernames.Where(u => u.Email == dto.Email).Count() > 0)
				throw new BadRequestException("This email is already in use");


			if (dto != null)
			{
				var user = _mapper.Map<User>(dto);
				user.Discuit = 0;
				user.CreatedAt = DateTime.Now;
				user.IsActive = true;
				var inserted = await _repo.InsertAsync(user);
				var dtoInserted = _mapper.Map<UserGetDto>(inserted);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status201Created,dtoInserted);
			}
			throw new BadRequestException("Enter the user information to add");
		}

		public async Task<ApiResponse<NoData>> DeleteUserAsync(int id)
		{
			var patchDoc = new JsonPatchDocument<User>();
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");

			var user = await _repo.GetByIdAsync(id);
			if(user != null)
			{
				patchDoc.Replace(p => p.IsActive, false);
				patchDoc.ApplyTo(user);
				await _repo.PatchAsync(user);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("User not found");
		}

		public async Task<ApiResponse<List<UserGetDto>>> GetAllUsers(params string[] includeList)
		{
			var users = await _repo.GetAllsAsync(includeList);
			var filteredUsers = users.Where(e => e.IsActive == true).ToList();
			if(filteredUsers != null)
			{
				var dtoList = _mapper.Map<List<UserGetDto>>(filteredUsers);
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
			if (user != null && user.IsActive == true)
			{
				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			_logger.LogInfo($"User with id:{id} could not found");
			throw new NotFoundException("User not found");
		}

		public async Task<ApiResponse<UserGetDto>> LoginAsync(string userName, string password)
		{
			userName = userName.Trim();
			if(userName == null || password == null)
				throw new BadRequestException("username or password cannot be null");

			var user = await _repo.GetByUserNameAndPassword(userName, password);
			if(user != null && user.IsActive == true)
			{
				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Username or password was wrong");
		}

      
        public async Task<ApiResponse<NoData>> UpdateUserAsync(UserPutDto dto)
        {
			var oldUser = _repo.GetByIdAsync(dto.UserId);
           if(dto != null)
			{
				var user = _mapper.Map<User>(dto);
				await _repo.UpdateAsync(user);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
            throw new BadRequestException("Enter the user information to update");
        }

		public async Task<ApiResponse<NoData>> PatchUserAsync(UserPutDto dto)
		{
			var user = await _repo.GetByIdAsync(dto.UserId);
            var patchDoc = new JsonPatchDocument<User>();

			var file = dto.File;
			if (file != null)
			{
				var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
				var imagePath = $@"/PostImages/{randomFileName}";
				var uploadPath = $@"{_webHost.ContentRootPath}/wwwroot{imagePath}";

				using var fs = new FileStream(uploadPath, FileMode.Create);
				file.CopyTo(fs);
				fs.Dispose();

				var base64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(uploadPath));
				patchDoc.Replace(p => p.UserImage, Convert.FromBase64String(base64));
                patchDoc.Replace(p => p.ImageRoute, uploadPath);

            }

            patchDoc.Replace(p => p.FirstName, dto.FirstName);
            patchDoc.Replace(p => p.LastName, dto.LastName);
            patchDoc.Replace(p => p.Gender, dto.Gender);
            patchDoc.Replace(p => p.BirthDate, DateTime.Parse(dto.BirthDate));
            patchDoc.Replace(p => p.Country, dto.Country);
			patchDoc.Replace(p => p.About, dto.About);

            patchDoc.ApplyTo(user);
			await _repo.PatchAsync(user);
			return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }

        public async Task<ApiResponse<NoData>> ProfileSetupAsync(UserSetUpDto dto)
        {
            var user = await _repo.GetByIdAsync(dto.UserId);
            var patchDoc = new JsonPatchDocument<User>();

            var file = dto.File;
            if (file != null)
            {
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(file.FileName)}";
                var imagePath = $@"/PostImages/{randomFileName}";
                var uploadPath = $@"{_webHost.ContentRootPath}/wwwroot{imagePath}";

                using var fs = new FileStream(uploadPath, FileMode.Create);
                file.CopyTo(fs);
                fs.Dispose();

                var base64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(uploadPath));
                patchDoc.Replace(p => p.UserImage, Convert.FromBase64String(base64));
                patchDoc.Replace(p => p.ImageRoute, uploadPath);

            }
            patchDoc.Replace(p => p.FirstName, dto.FirstName);
            patchDoc.Replace(p => p.LastName, dto.LastName);
            patchDoc.Replace(p => p.Gender, dto.Gender);
            patchDoc.Replace(p => p.Country, dto.Country);

            patchDoc.ApplyTo(user);
            await _repo.PatchAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);

        }

		public async Task<ApiResponse<UserGetDto>> AdminLoginAsync(string userName, string password)
		{
			userName = userName.Trim();
			if (userName == null || password == null)
				throw new BadRequestException("username or password cannot be null");

			var user = await _repo.GetByUserNameAndPassword(userName, password);
			if (user != null && user.IsAdmin == true && user.IsActive == true)
			{

				var dto = _mapper.Map<UserGetDto>(user);
				return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Username or password was wrong");
		}
	}
}
