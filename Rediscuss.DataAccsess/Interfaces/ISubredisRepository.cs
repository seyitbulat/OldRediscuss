using Infrastructure.DataAccess.Interfaces;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.DataAccsess.Interfaces
{
	public interface ISubredisRepository : IBaseRepository<Subredis>
	{
		Task<Subredis> GetByIdAsync(int id, params string[] includeList);
		Task<List<Subredis>> GetByNameAsync(string name, params string[] includeList);
		Task<List<Subredis>> GetByDescriptionAsync(string description, params string[] includeList);

		Task<List<Subredis>> GetSuggestionAsync(int userId, params string[] includeList);
	}
}
