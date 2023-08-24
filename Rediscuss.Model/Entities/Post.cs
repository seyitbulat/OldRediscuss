using Infrastructure.Model;

namespace Rediscuss.Model.Entities
{
    public class Post : IEntity
    {
        public int? PostId { get; set; }
        public string? PostTitle { get; set; }
        public string? PostBody { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? SubredisId { get; set; }
        public bool? IsActive { get; set; }

        // Navigation Properites

        public List<Comment> Comments { get; set; }
        public User User { get; set; }
        public Subredis Subredis { get; set; }
        //public List<Vote> Votes { get; set; }
        public List<PostImage> PostImages { get; set; }
    }
}
