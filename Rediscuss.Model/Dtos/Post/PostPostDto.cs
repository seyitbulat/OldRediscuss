﻿namespace Rediscuss.Model.Dtos.Post
{
	public class PostPostDto
	{
		public string PostTitle { get; set; }
		public string PostBody { get; set; }
		public int CreatedBy { get; set; }
		public int SubredisId { get; set; }
	}
}
