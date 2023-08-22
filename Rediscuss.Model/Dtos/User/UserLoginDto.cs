using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Model.Dtos.User
{
    public class UserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
