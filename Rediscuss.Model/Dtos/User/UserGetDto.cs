using Infrastructure.Model;
using Infrastructure.Utilities.Security.JWT;
using Rediscuss.Model.Dtos.Comment;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Entities;

namespace Rediscuss.Model.Dtos.User
{
    public class UserGetDto : IDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Discuit { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UserImage { get; set; }
        public string? ImageRoute { get; set; }
        public string? About { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? BirthDate { get; set; }
        public string? Country { get; set; }
        public bool? IsActive { get; set; }


        //public string? ContentType { get; set; }
        //{
        //    get
        //    {
        //        return ContentType;
        //    }
        //    set
        //    {
        //        if(ImageRoute != null)
        //        {
        //            value = "image/" + Path.GetExtension(ImageRoute);
        //        }
        //    }
        //}
        public string Token { get; set; } = null;
    }
}
