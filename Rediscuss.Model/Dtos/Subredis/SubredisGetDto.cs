namespace Rediscuss.Model.Dtos.Subredis
{
	public class SubredisGetDto
	{
		public int SubredisId { get; set; }
		public string SubredisName { get; set; }
		public string SubredisDescription { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CreatedBy { get; set; }
	}
}
