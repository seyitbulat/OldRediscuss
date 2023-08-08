using Microsoft.EntityFrameworkCore;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Contexts
{
	public class RediscussContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Rediscuss;Trusted_Connection=True;");
		}

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Join> Joins { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subredis> Subredises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}
