using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface IPostRepository : IBaseRepository<Post>
	{
		Task<Post> GetByIdAsync(int id, params string[] includeList);
		Task<List<Post>> GetByTitleAsync(string title, params string[] includeList);
		Task<List<Post>> GetByBodyAsync(string body, params string[] includeList);
		Task<List<Post>> GetByDateAsync(int min, int max, params string[] includeList);
		Task<List<Post>> GetBySubredisIdAsync(int subredisId, params string[] includeList);
		Task<List<Post>> GetByUserIdAsync(int userId, params string[] includeList);

    }
}
