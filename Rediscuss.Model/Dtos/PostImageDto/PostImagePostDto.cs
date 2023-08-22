namespace Rediscuss.Model.Dtos.PostImageDto
{
    public class PostImagePostDto
    {
        public int PostId { get; set; }
        public string Base64Picture { get; set; }
        public string ImageRoute { get; set; }
        public string ContentType { get; set; }
    }
}
