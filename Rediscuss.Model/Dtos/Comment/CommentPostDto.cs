using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Model.Dtos.Comment
{
	public class CommentPostDto : IDto
	{
		public int CommentId { get; set; }
		public string CommentBody { get; set; }
		public int CreatedBy { get; set; }
		public int PostId { get; set; }
	}
}
