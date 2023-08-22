using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
	public class Subredis : IEntity
	{
        public int SubredisId { get; set; }
        public string SubredisName { get; set; }
        public string SubredisDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public byte[]? SubredisImage { get; set; }
        public string? ImageRoute { get; set; }
        public bool? IsActive { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public List<Join> Joins { get; set; }
        public List<Post> Posts { get; set; }

    }
}
