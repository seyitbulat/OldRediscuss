using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class JoinRepository : BaseRepository<Join, RediscussContext>, IJoinRepository
	{
		public async Task<List<Join>> GetBySubredisId(int subredisId, params string[] includeList)
		{
			return await GetAllAsync(j => j.SubredisId == subredisId, includeList);
		}

		public async Task<List<Join>> GetByUserId(int userId, params string[] includeList)
		{
			return await GetAllAsync(j => j.UserId == userId, includeList);
		}
	}
}
