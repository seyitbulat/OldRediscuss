using Rediscuss.Model.Dtos.Comment;
using Rediscuss.Model.Dtos.PostImageDto;
using Rediscuss.Model.Dtos.Subredis;

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


		
        //public string? PostPicture { get; set; }
        //public string? ImageRoute { get; set; }

        public string SubredisName { get; set; }
		public string PostedByImage { get; set; }
		public string PostedBy { get; set; }

        public List<CommentGetDto> Comments { get; set; }
		public List<PostImageGetDto> PostImages { get; set; }

    }
}
