using Infrastructure.Model;

namespace Rediscuss.Model.Dtos.Subredis
{
	public class SubredisPostDto : IDto
	{
		public string SubredisName { get; set; }
		public string SubredisDescription { get; set; }
		public int CreatedBy { get; set; }
	}
}
