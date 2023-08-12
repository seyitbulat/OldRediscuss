using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class PostRepository : BaseRepository<Post, RediscussContext>, IPostRepository
	{
		public Task<List<Post>> GetByBodyAsync(string body)
		{
			return GetAllAsync(p => p.PostTitle.ToLower().Contains(body.ToLower()));
		}

		public Task<List<Post>> GetByDateAsync(int min, int max)
		{
			return GetAllAsync(p =>
				p.CreatedAt.Date.Year >= min && p.CreatedAt.Date.Year <= max);
		}

		public Task<Post> GetByIdAsync(int id)
		{
			return GetAsync(p => p.PostId == id);
		}

		public Task<List<Post>> GetBySubredisIdAsync(int subredisId)
		{
			return GetAllAsync(p => p.SubredisId == subredisId);
		}

		public Task<List<Post>> GetByTitleAsync(string title)
		{
			return GetAllAsync(p => p.PostTitle.ToLower().Contains(title.ToLower()));
		}
	}
}
