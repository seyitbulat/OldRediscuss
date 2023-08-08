﻿using Infrastructure.Model;

namespace Rediscuss.Model.Dtos.User
{
	public class UserPostDto : IDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int Discuit { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
