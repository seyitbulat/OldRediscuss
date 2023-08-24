using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Model.Dtos.Subredis
{
	public class SubredisGetDto
	{
		public int SubredisId { get; set; }
		public string SubredisName { get; set; }
		public string SubredisDescription { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CreatedBy { get; set; }
		public string? SubredisImage { get; set; }

        public List<PostGetDto> Posts { get; set; }
    }
}
