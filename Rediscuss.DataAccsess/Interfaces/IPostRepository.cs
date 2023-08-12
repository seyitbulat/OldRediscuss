using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface IPostRepository : IBaseRepository<Post>
	{
		Task<Post> GetByIdAsync(int id);
		Task<List<Post>> GetByTitleAsync(string title);
		Task<List<Post>> GetByBodyAsync(string body);
		Task<List<Post>> GetByDateAsync(int min, int max);
		Task<List<Post>> GetBySubredisIdAsync(int subredisId);
	}
}
