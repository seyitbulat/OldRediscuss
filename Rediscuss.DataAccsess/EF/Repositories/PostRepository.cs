using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class PostRepository : BaseRepository<Post, RediscussContext>, IPostRepository
	{
		public async Task<List<Post>> GetByBodyAsync(string body, params string[] includeList)
		{
			return await GetAllAsync(p => p.PostTitle.ToLower().Contains(body.ToLower()), includeList);
		}

		public async Task<List<Post>> GetByDateAsync(int min, int max, params string[] includeList)
		{
			return await GetAllAsync(p =>
				p.CreatedAt.Date.Year >= min && p.CreatedAt.Date.Year <= max, includeList);
		}

		public async Task<Post> GetByIdAsync(int id, params string[] includeList)
		{
			return await GetAsync(p => p.PostId == id, includeList);
		}

		public async Task<List<Post>> GetBySubredisIdAsync(int subredisId, params string[] includeList)
		{
			return await GetAllAsync(p => p.SubredisId == subredisId, includeList);
		}

		public async Task<List<Post>> GetByTitleAsync(string title, params string[] includeList)
		{
			return await GetAllAsync(p => p.PostTitle.ToLower().Contains(title.ToLower()), includeList);
		}

        public async Task<List<Post>> GetByUserIdAsync(int userId, params string[] includeList)
        {
			return await GetAllAsync(p => p.CreatedBy == userId, includeList);
        }
    }
}
