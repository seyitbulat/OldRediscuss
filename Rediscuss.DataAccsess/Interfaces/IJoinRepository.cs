using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface IJoinRepository : IBaseRepository<Join>
	{
		Task<List<Join>> GetByUserId(int userId, params string[] includeList);
		Task<List<Join>> GetBySubredisId(int subredisId, params string[] includeList);
	}
}
