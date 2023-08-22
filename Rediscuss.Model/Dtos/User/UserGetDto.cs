﻿using Infrastructure.Model;
using Infrastructure.Utilities.Security.JWT;
using Rediscuss.Model.Dtos.Join;

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
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public bool? IsActive { get; set; }


        public string Token { get; set; } = null;
    }
}
