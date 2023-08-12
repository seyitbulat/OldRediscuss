namespace Rediscuss.Model.Dtos.Post
{
	public class PostGetDto
	{
		public int PostId { get; set; }
		public string PostTitle { get; set; }
		public string PostBody { get; set; }
		public string PostImage { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CreatedBy { get; set; }
		public int SubredisId { get; set; }
	}
}
