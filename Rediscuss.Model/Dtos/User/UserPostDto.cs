using Infrastructure.Model;
using System.ComponentModel.DataAnnotations;

namespace Rediscuss.Model.Dtos.User
{
	public class UserPostDto : IDto
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
	}
}
