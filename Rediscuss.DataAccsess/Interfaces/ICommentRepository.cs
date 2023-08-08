using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
		Task<Comment> GetByIdAsync(Comment comment);
		List<Task<Comment>> GetAllAsync(); 
	}
}
