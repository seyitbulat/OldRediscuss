using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
	public class Join : IEntity
	{
        public int UserId { get; set; }
        public int Subredisid { get; set; }
        public DateTime JoinedAt { get; set; }

        // Navigation Property

        public User User { get; set; }
        public Subredis Subredis { get; set; }
    }
}
