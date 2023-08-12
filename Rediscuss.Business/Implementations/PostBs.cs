using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.EF.Repositories;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Dtos.User;

namespace Rediscuss.Business.Implementations
{
	public class PostBs : IPostBs
	{
		private readonly IPostRepository _repo;
		private readonly IMapper _mapper;

		public PostBs(IPostRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}


		public async Task<ApiResponse<List<PostGetDto>>> GetByBodyAsync(string body)
		{
			if (body == null)
				throw new BadRequestException("Enter a body");

			var posts = await _repo.GetByBodyAsync(body);
			if (posts != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(posts);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public Task<ApiResponse<List<PostGetDto>>> GetByDateAsync(int min, int max)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<PostGetDto>> GetByIdAsync(int id)
		{
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");
			if (id == null)
				throw new BadRequestException("Enter an id");
			var post = await _repo.GetByIdAsync(id);
			if (post != null)
			{
				var dto = _mapper.Map<PostGetDto>(post);
				return ApiResponse<PostGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetBySubredisIdAsync(int subredisId)
		{
			if (subredisId < 0)
				throw new BadRequestException("Id cannot be negative");
			if (subredisId == null)
				throw new BadRequestException("Enter an subredis id");
			var posts = await _repo.GetBySubredisIdAsync(subredisId);
			if (posts != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(posts);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetByTitleAsync(string title)
		{
			if (title == null)
				throw new BadRequestException("Enter a title");

			var posts = await _repo.GetByTitleAsync(title);
			if(posts != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(posts);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}
	}
}
