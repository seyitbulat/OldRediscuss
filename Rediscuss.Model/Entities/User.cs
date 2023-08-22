using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rediscuss.Model.Entities
{
	public class User : IEntity
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int Discuit { get; set; }
		public DateTime CreatedAt { get; set; }
        public byte[]? UserImage { get; set; }
        public string? ImageRoute { get; set; }
        public string? About { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
		public string? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public bool? IsActive { get; set; }

        // Navigation Properties

        public List<Vote> Votes { get; set; }
		public List<Post> Posts { get; set; }
		public List<Subredis> Subredises { get; set; }
		public List<Comment> Comments { get; set; }
		public List<Join> Joins { get; set; }
		//public List<Friend> Friends { get; set; }

		[NotMapped]
		public string Base64Picture
		{
			get
			{
				if(UserImage != null)
				{
					var base64 = string.Empty;
					using var ms = new MemoryStream();
					ms.Write(UserImage,0,UserImage.Length);
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
