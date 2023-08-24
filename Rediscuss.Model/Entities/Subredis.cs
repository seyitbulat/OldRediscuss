using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rediscuss.Model.Entities
{
	public class Subredis : IEntity
	{
        public int SubredisId { get; set; }
        public string SubredisName { get; set; }
        public string SubredisDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public byte[]? SubredisImage { get; set; }
        public string? ImageRoute { get; set; }
        public bool? IsActive { get; set; }


		[NotMapped]
		public string Base64Picture
		{
			get
			{
				if (SubredisImage != null)
				{
					var base64 = string.Empty;
					using var ms = new MemoryStream();
					ms.Write(SubredisImage, 0, SubredisImage.Length);
					var bmp = new System.Drawing.Bitmap(ms);
					using var jpegms = new MemoryStream();
					bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
					base64 = Convert.ToBase64String(jpegms.ToArray());
					return base64;
				}
				return string.Empty;
			}
			set
			{
				Base64Picture = value;
			}
		}

		// Navigation Properties
		public User User { get; set; }
        public List<Join> Joins { get; set; }
        public List<Post> Posts { get; set; }

    }
}
