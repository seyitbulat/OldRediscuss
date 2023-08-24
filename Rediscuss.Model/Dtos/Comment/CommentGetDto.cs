using Infrastructure.Model;
using Rediscuss.Model.Dtos.User;

namespace Rediscuss.Model.Dtos.Comment
{
    public class CommentGetDto : IDto
	{
		public int CommentId { get; set; }
		public string CommentBody { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CreatedBy { get; set; }
		public int PostId { get; set; }

		public string CreatedByName { get; set; }
        public string? UserImage { get; set; }
        public string? ImageRoute { get; set; }
    }
}
