using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rediscuss.Model.Entities
{
    public class PostImage : IEntity
    {
        public int PostId { get; set; }
        public byte[]? PostPicture { get; set; }
        public string? ImageRoute { get; set; }
        public string? ContentType { get; set; }
        public bool? IsActive { get; set; }

        public Post Post { get; set; }

        [NotMapped]
        public string Base64Picture
        {
            get
            {
                if (PostPicture != null)
                {
                    var base64 = string.Empty;
                    using var ms = new MemoryStream();
                    ms.Write(PostPicture, 0, PostPicture.Length);
                    var bmp = new System.Drawing.Bitmap(ms);
                    using var jpegms = new MemoryStream();
                    bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    base64 = Convert.ToBase64String(jpegms.ToArray());
                    return base64;
                }
                return string.Empty;
            }
        }
    }
}
