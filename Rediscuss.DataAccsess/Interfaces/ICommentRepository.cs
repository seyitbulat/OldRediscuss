using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
		Task<Comment> GetByIdAsync(int id, params string[] includeList);
		Task<List<Comment>> GetByPostIdAsync(int postId, params string[] includeList);
	}
}
