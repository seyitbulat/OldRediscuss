using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Model.Dtos.User
{
	public class UserSignupDto : IDto
	{
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
