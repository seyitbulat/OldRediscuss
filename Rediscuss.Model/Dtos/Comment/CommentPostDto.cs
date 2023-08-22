using Infrastructure.Model;

namespace Rediscuss.Model.Dtos.Comment
{
    public class CommentPostDto : IDto
	{
		public int CommentId { get; set; }
		public string CommentBody { get; set; }
		public int CreatedBy { get; set; }
		public int PostId { get; set; }
	}
}
