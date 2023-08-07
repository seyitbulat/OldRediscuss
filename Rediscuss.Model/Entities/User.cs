using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
	public class User : IEntity
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int Discuit { get; set; }
		public DateTime CreatedAt { get; set; }

		// Navigation Properties

		public List<Vote> Votes { get; set; }
		public List<Post> Posts { get; set; }
		public List<Subredis> Subredises { get; set; }
		public List<Comment> Comments { get; set; }
		public List<Join> Joins { get; set; }
	}
}
