using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Model.Dtos.Join
{
	public class JoinGetDto
	{
		public int UserId { get; set; }
		public int SubredisId { get; set; }
		public DateTime JoinedAt { get; set; }
        public string SubredisName { get; set; }

    }
}
