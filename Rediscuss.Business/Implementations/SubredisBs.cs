using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Implementations
{
	public class SubredisBs : ISubredisBs
	{
		private readonly ISubredisRepository _repo;
		private readonly IMapper _mapper;

        public SubredisBs(ISubredisRepository repo, IMapper mapper)
        {
            _repo = repo;
			_mapper = mapper;
        }

        public async Task<ApiResponse<Subredis>> AddSubredisAsync(SubredisPostDto dto)
		{
			if(dto != null)
			{
				var subredis = _mapper.Map<Subredis>(dto);
				subredis.CreatedAt = DateTime.Now;
				var inserted = await _repo.InsertAsync(subredis);
				return ApiResponse<Subredis>.Success(StatusCodes.Status201Created,inserted);
			}
			throw new BadRequestException("Enter the subredis information to add");
		}

		public async Task<ApiResponse<NoData>> DeleteSubredisAsync(int id)
		{
			if (id <= 0)
				throw new BadRequestException("Id cannot be negative");
			var patchDoc = new JsonPatchDocument<Subredis>();
			var subredis = await _repo.GetByIdAsync(id);
			if (subredis != null)
			{
				patchDoc.Replace(e => e.IsActive, false);
				patchDoc.ApplyTo(subredis);
				await _repo.PatchAsync(subredis);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("No suitable subredis was found based on the ID entered.");
		}

		public async Task<ApiResponse<List<SubredisGetDto>>> GetAllAsync(params string[] includeList)
		{
			var subredis = await _repo.GetAllAsync(includeList: includeList);
			var filtered = subredis.Where(e => e.IsActive == true).ToList();
			if(filtered != null)
			{
				var dtoList = _mapper.Map<List<SubredisGetDto>>(filtered);
				return ApiResponse<List<SubredisGetDto>>.Success(StatusCodes.Status200OK, dtoList);
			}
			throw new NotFoundException("Subredis not found");
		}

		public async Task<ApiResponse<List<SubredisGetDto>>> GetByDescriptionAsync(string description, params string[] includeList)
		{
			if (description == null)
				throw new BadRequestException("Enter a description");

			var subredises = await _repo.GetByDescriptionAsync(description, includeList);
			var filtered = subredises.Where(e => e.IsActive == true).ToList();
			if (filtered != null)
			{
				var dto = _mapper.Map<List<SubredisGetDto>>(filtered);
				return ApiResponse<List<SubredisGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Subredis not found");
		}

		public async Task<ApiResponse<SubredisGetDto>> GetByIdAsync(int id, params string[] includeList)
		{
			if (id < 0)
				throw new BadRequestException("Id cannot be negative");
			if (id == null)
				throw new BadRequestException("Enter an id");
			var subredis = await _repo.GetByIdAsync(id, includeList);
			if (subredis != null && subredis.IsActive == true)
			{
				var dto = _mapper.Map<SubredisGetDto>(subredis);
				return ApiResponse<SubredisGetDto>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Subredis not found");
		}

		public Task<ApiResponse<List<SubredisGetDto>>> GetByJoinedUsers(int subredisId, params string[] includeList)
		{
			throw new NotImplementedException();
		}

		public async Task<ApiResponse<List<SubredisGetDto>>> GetByNameAsync(string name, params string[] includeList)
		{
			if (name == null)
				throw new BadRequestException("Enter a name");

			var subredises = await _repo.GetByNameAsync(name, includeList);
			var filtered = subredises.Where(e => e.IsActive == true).ToList();
			if (filtered != null)
			{
				var dto = _mapper.Map<List<SubredisGetDto>>(filtered);
				return ApiResponse<List<SubredisGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Subredis not found");
		}

		public async Task<ApiResponse<List<SubredisGetDto>>> GetSuggestionAsync(int userId, params string[] includeList)
		{
			var subredises = await _repo.GetSuggestionAsync(userId, includeList);
			var filtered = subredises.Where(e => e.IsActive == true).ToList();
			if (filtered != null)
            {
                var dto = _mapper.Map<List<SubredisGetDto>>(filtered);
                return ApiResponse<List<SubredisGetDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Subredis not found");
        }

    }
}
