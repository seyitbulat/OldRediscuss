using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Implementations
{
	public class JoinBs : IJoinBs
	{
		private readonly IJoinRepository _repo;
		private readonly IMapper _mapper;

		public JoinBs(IJoinRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper = mapper;
		}

		public Task<ApiResponse<Join>> DeleteJoinAsync(int userId, int subredisId)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<List<JoinGetDto>>> GetBySubredisIdAsync(int subredisId, params string[] includeList)
		{
			if (subredisId < 0)
				throw new BadRequestException("Subredis Id cannot be negative");
			if (subredisId == null)
				throw new BadRequestException("Enter an id");
			var joins = await _repo.GetBySubredisId(subredisId, includeList);
			if (joins != null)
			{
				var dto = _mapper.Map<List<JoinGetDto>>(joins);
				return ApiResponse<List<JoinGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Join not found");
		}

		public async Task<ApiResponse<List<JoinGetDto>>> GetByUserIdAsync(int userId, params string[] includeList)
		{
			if (userId < 0)
				throw new BadRequestException("User Id cannot be negative");
			if (userId == null)
				throw new BadRequestException("Enter an id");
			var joins = await _repo.GetByUserId(userId, includeList);
			if (joins != null)
			{
				var dto = _mapper.Map<List<JoinGetDto>>(joins);
				return ApiResponse<List<JoinGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Join not found");
		}

		public async Task<ApiResponse<Join>> AddJoinAsync(JoinPostDto dto)
		{
			if(dto != null)
			{
				var join = _mapper.Map<Join>(dto);
				join.JoinedAt = DateTime.Now;
				join.IsActive = true;
				var inserted = await _repo.InsertAsync(join);
				return ApiResponse<Join>.Success(StatusCodes.Status201Created, inserted);
			}
			throw new BadRequestException("Enter the join information to add");
		}

		public async Task<ApiResponse<NoData>> UpdateJoinAsync(JoinPutDto dto)
		{
			if(dto != null)
			{
				if (dto.SubredisId < 0)
					throw new BadRequestException("Subredis Id cannot be negative");

				if (dto.UserId < 0)
					throw new BadRequestException("User Id cannot be negative");

				var join = _mapper.Map<Join>(dto);
				await _repo.UpdateAsync(join);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new BadRequestException("Enter the join information to update");
		}
	}
}
