using Infrastructure.DataAccess.Implementations.EF;
using Rediscuss.DataAccsess.EF.Contexts;
using Rediscuss.DataAccsess.Interfaces;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.DataAccsess.EF.Repositories
{
	public class CommentRepository : BaseRepository<Comment, RediscussContext>, ICommentRepository
	{

		public async Task<Comment> GetByIdAsync(int id, params string[] includeList)
		{
			return await GetAsync(c => c.CommentId == id, includeList);
		}

		public async Task<List<Comment>> GetByPostIdAsync(int postId, params string[] includeList)
		{
			return await GetAllAsync(c => c.PostId == postId, includeList);
		}
	}
}
