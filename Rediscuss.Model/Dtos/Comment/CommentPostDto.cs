using Infrastructure.Model;

namespace Rediscuss.Model.Dtos.Comment
{
    public class CommentPostDto : IDto
	{
		public string CommentBody { get; set; }
		public int CreatedBy { get; set; }
		public int PostId { get; set; }
	}
}
