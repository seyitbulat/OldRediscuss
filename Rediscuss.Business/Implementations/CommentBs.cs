using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.Comment;
using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Entities;
using System.Diagnostics.Metrics;

namespace Rediscuss.Business.Implementations
{
	public class CommentBs : ICommentBs
	{
		private readonly ICommentRepository _repo;
		private readonly IMapper _mapper;

		public CommentBs(ICommentRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		

		public async Task<ApiResponse<Comment>> AddCommentAsync(CommentPostDto dto)
		{
			if(dto != null)
			{
				var comment = _mapper.Map<Comment>(dto);
				comment.CreatedAt = DateTime.Now;
				var inserted = await _repo.InsertAsync(comment);
				return ApiResponse<Comment>.Success(StatusCodes.Status201Created, comment);
			}
			throw new BadRequestException("Enter the comment information to add");
		}

		public async Task<ApiResponse<NoData>> DeleteCommentAsync(int id)
		{
			if (id <= 0)
				throw new BadRequestException("Id cannot be negative");

			var comment = await _repo.GetByIdAsync(id);
			if (comment != null)
			{
				await _repo.DeleteAsync(comment);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("No suitable comment was found based on the ID entered");
		}

		public async Task<ApiResponse<CommentGetDto>> GetByIdAsync(int id, params string[] includeList)
		{
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");
			if (id == null)
				throw new BadRequestException("Enter an id");
			var comment = await _repo.GetByIdAsync(id, includeList);
			if (comment != null)
			{
				var dto = _mapper.Map<CommentGetDto>(comment);
				return ApiResponse<CommentGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Comment not found");
		}

		public async Task<ApiResponse<List<CommentGetDto>>> GetByPostIdAsync(int postId, params string[] includeList)
		{
			if (postId < 0)
				throw new BadRequestException("Post Id cannot be negative");
			if (postId == null)
				throw new BadRequestException("Enter an id");
			var comments = await _repo.GetByPostIdAsync(postId, includeList);
			if (comments != null)
			{
				var dto = _mapper.Map<List<CommentGetDto>>(comments);
				return ApiResponse<List<CommentGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Comments not found");
		}
	}
}
