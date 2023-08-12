using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Rediscuss.Business.CustomExceptions;
using Rediscuss.Business.Interfaces;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

			var subredis = await _repo.GetByIdAsync(id);
			if (subredis != null)
			{
				await _repo.DeleteAsync(subredis);
				return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
			}
			throw new NotFoundException("No suitable subredis was found based on the ID entered.");
		}

		public async Task<ApiResponse<List<SubredisGetDto>>> GetByDescriptionAsync(string description, params string[] includeList)
		{
			if (description == null)
				throw new BadRequestException("Enter a description");

			var subredises = await _repo.GetByDescriptionAsync(description);
			if (subredises != null)
			{
				var dto = _mapper.Map<List<SubredisGetDto>>(subredises);
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
			if (subredis != null)
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

			var subredises = await _repo.GetByNameAsync(name);
			if (subredises != null)
			{
				var dto = _mapper.Map<List<SubredisGetDto>>(subredises);
				return ApiResponse<List<SubredisGetDto>>.Success(StatusCodes.Status200OK, dto);
			}
			throw new NotFoundException("Subredis not found");
		}
	}
}
