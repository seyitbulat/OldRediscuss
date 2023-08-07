using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
	public class Comment : IEntity
	{
        public int CommentId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int PostId { get; set; }

        // Navigation Property
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
