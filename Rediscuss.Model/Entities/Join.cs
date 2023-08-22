using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
	public class Join : IEntity
	{
        public int UserId { get; set; }
        public int SubredisId { get; set; }
        public DateTime JoinedAt { get; set; }
        public bool? IsActive { get; set; }

        // Navigation Property

        public User User { get; set; }
        public Subredis Subredis { get; set; }
    }
}
