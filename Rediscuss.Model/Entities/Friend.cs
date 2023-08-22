using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
    public class Friend : IEntity
    {
        public int? FriendId { get; set; }
        public int? UserId { get; set; }
        public bool? NotificationSent { get; set; }

        public User User { get; set; }
    }
}
