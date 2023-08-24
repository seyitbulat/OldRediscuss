using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class SubredisRepository : BaseRepository<Subredis, RediscussContext>, ISubredisRepository
	{
		public Task<List<Subredis>> GetByDescriptionAsync(string description, params string[] includeList)
		{
			return GetAllAsync(s => s.SubredisDescription.ToLower().Contains(description.ToLower()),includeList);
		}

		public Task<Subredis> GetByIdAsync(int id, params string[] includeList)
		{
			var result = GetAsync(s => s.SubredisId == id, includeList);
			return GetAsync(s => s.SubredisId == id, includeList);
		}

		public Task<List<Subredis>> GetByNameAsync(string name, params string[] includeList)
		{
			return GetAllAsync(s => s.SubredisName.ToLower().Contains(name.ToLower()), includeList);
		}

		public async Task<List<Subredis>> GetSuggestionAsync(int userId, params string[] includeList)
		{
			var all = await GetAllAsync(includeList: includeList);
			
			var result = all.Where(s => !s.Joins.Any(j => j.UserId == userId)).ToList();

            return result;
		}

    }
}
