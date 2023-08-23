using Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Model.Dtos.User
{
    public class UserPutDto : IDto
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
        public string ContentType { get; set; }
        public string? About { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? BirthDate { get; set; }
        public string? Country { get; set; }
    }
}

