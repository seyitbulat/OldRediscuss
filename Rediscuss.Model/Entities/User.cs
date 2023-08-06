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

        
    }
}
