using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Model.Dtos.PostImageDto
{
    public class PostImageUploadDto
    {
        public IFormFile File { get; set; }
        public string ContentType { get; set; }
    }
}
