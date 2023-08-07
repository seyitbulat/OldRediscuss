using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
	public class Vote : IEntity
	{
        public int VoteId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int VoteCount { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation Properties

        public Post Post { get; set; }
        public User User { get; set; }

    }
}
