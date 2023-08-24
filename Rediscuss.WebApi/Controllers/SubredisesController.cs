using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rediscuss.Business.Interfaces;
using Rediscuss.Model.Dtos.Subredis;

namespace Rediscuss.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubredisesController : BaseController
	{
		private readonly ISubredisBs _subredisBs;

		public SubredisesController(ISubredisBs subredisBs)
		{
			_subredisBs = subredisBs;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllSubredises()
		{
			var response = await _subredisBs.GetAllAsync("User");
			return await SendResponse(response);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
		{
			var response = await _subredisBs.GetByIdAsync(id, "Posts");
			return await SendResponse(response);
		}

		[HttpGet("getByName")]
		public async Task<IActionResult> GetByNameAsync([FromQuery] string name)
		{
			var response = await _subredisBs.GetByNameAsync(name);
			return await SendResponse(response);
		}

		[HttpGet("getByDescription")]
		public async Task<IActionResult> GetByDescriptionAsync([FromQuery] string description)
		{
			var response = await _subredisBs.GetByDescriptionAsync(description);
			return await SendResponse(response);
		}

		[HttpGet("getSuggestion")]
		public async Task<IActionResult> GetSuggestionAsync([FromQuery] int userId)
		{
			var response = await _subredisBs.GetSuggestionAsync(userId, "Joins");
			return await SendResponse(response);
		}

		[HttpPost]
		public async Task<IActionResult> AddSubredisAsync([FromBody] SubredisPostDto dto)
		{
			var response = await _subredisBs.AddSubredisAsync(dto);
			return CreatedAtAction(nameof(GetByIdAsync), new { id = response.Data.SubredisId }, dto);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteSubredisAsync([FromQuery] int id)
		{
			var response = await _subredisBs.DeleteSubredisAsync(id);
			return await SendResponse(response);
		}
	}
}
