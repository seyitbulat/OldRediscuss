namespace Rediscuss.Model.Dtos.PostImageDto
{
    public class PostImageGetDto
    {
        public int PostId { get; set; }
        public string PostPicture { get; set; }
        public string ImageRoute { get; set; }

        public string ContentType { get; set; }
    }
}
