﻿using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Hosting;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Implementations
{
	public class PostBs : IPostBs
	{
		private readonly IPostRepository _repo;
		private readonly IJoinRepository _joinRepository;
		private readonly IPostImageRepository _postImageRepository;
		private readonly IWebHostEnvironment _webHost;
		private readonly IMapper _mapper;

		public PostBs(IPostRepository repo, IMapper mapper, IJoinRepository joinRepository, IPostImageRepository postImageRepository, IWebHostEnvironment webHost)
		{
			_repo = repo;
			_mapper = mapper;
			_joinRepository = joinRepository;
			_postImageRepository = postImageRepository;
			_webHost = webHost;
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetByBodyAsync(string body, params string[] includeList)
		{
			if (body == null)
				throw new BadRequestException("Enter a body");

			var posts = await _repo.GetByBodyAsync(body);
			var filtered = posts.Where(e => e.IsActive == true).ToList();
			if (filtered != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(filtered);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<PostGetDto>> AddPostAsync(PostPostDto dto)
		{
			if (dto != null)
			{
				var post = _mapper.Map<Post>(dto);
				post.CreatedAt = DateTime.Now;
				post.IsActive = true;
				var inserted = await _repo.InsertAsync(post);
				var response = _mapper.Map<PostGetDto>(inserted);

				return ApiResponse<PostGetDto>.Success(StatusCodes.Status201Created, response);
			}
			throw new BadRequestException("Enter a body");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetAllPostsAsync(params string[] includeList)
		{
			var posts = await _repo.GetAllAsync(includeList: includeList);
			var filtered = posts.Where(e => e.IsActive == true).ToList();
			if (filtered != null)
			{
				var dtoList = _mapper.Map<List<PostGetDto>>(filtered);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dtoList);
			}
			throw new NotFoundException("Posts not found");
		}


		public Task<ApiResponse<List<PostGetDto>>> GetByDateAsync(int min, int max, params string[] includeList)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<PostGetDto>> GetByIdAsync(int id, params string[] includeList)
		{
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");
			if (id == null)
				throw new BadRequestException("Enter an id");
			var post = await _repo.GetByIdAsync(id, includeList);
			if (post != null && post.IsActive == true)
			{
				var dto = _mapper.Map<PostGetDto>(post);
				return ApiResponse<PostGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetByJoinedUsersAsync(int userId, params string[] includeList)
		{
			var joinedSubredises = await _joinRepository.GetByUserId(userId);
			var subredisList = joinedSubredises.Select(s => s.SubredisId).ToList();
			List<Post> post = new();
			foreach (var subredisId in subredisList)
			{
				var posts = await _repo.GetBySubredisIdAsync(subredisId, includeList);
				posts.Where(e => e.SubredisId == subredisId).Select(e => e.Subredis.Posts = null);
				post.AddRange(posts);
			}
			var filtered = post.Where(e => e.IsActive == true).ToList();
			if (filtered != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(filtered);
				var ordered = dto.OrderByDescending(e => e.CreatedAt).ToList();
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, ordered);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetBySubredisIdAsync(int subredisId, params string[] includeList)
		{
			if (subredisId < 0)
				throw new BadRequestException("Id cannot be negative");
			if (subredisId == null)
				throw new BadRequestException("Enter an subredis id");
			var posts = await _repo.GetBySubredisIdAsync(subredisId, includeList);
			var filtered = posts.Where(e => e.IsActive == true).ToList();

			if (filtered != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(filtered);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetByTitleAsync(string title, params string[] includeList)
		{
			if (title == null)
				throw new BadRequestException("Enter a title");

			var posts = await _repo.GetByTitleAsync(title);
			var filtered = posts.Where(e => e.IsActive == true).ToList();

			if (filtered != null)
			{
				var dto = _mapper.Map<List<PostGetDto>>(filtered);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<List<PostGetDto>>> GetByUserIdAsync(int userId, params string[] includeList)
		{
			if (userId < 0)
				throw new BadRequestException("Id cannot be negative");

			var posts = await _repo.GetByUserIdAsync(userId, includeList);
			var filtered = posts.Where(e => e.IsActive == true).ToList();

			if (filtered != null)
			{
				var dtoList = _mapper.Map<List<PostGetDto>>(filtered);
				return ApiResponse<List<PostGetDto>>.Success(StatusCodes.Status200OK, dtoList);
			}
			throw new NotFoundException("Post not found");
		}

		public async Task<ApiResponse<NoData>> DeletePostAsync(int postId)
		{
			var patchDoc = new JsonPatchDocument<Post>();
			if (postId < 0)
				throw new BadRequestException("Id cannot be negative");

			var post = await _repo.GetByIdAsync(postId);
			if (post != null)
			{
				patchDoc.Replace(p => p.IsActive, false);
				patchDoc.ApplyTo(post);
				await _repo.PatchAsync(post);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("Post not found");
		}
	}
}
