using Microsoft.EntityFrameworkCore;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Contexts
{
	public class RediscussContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Join>()
				.HasKey("UserId", "SubredisId");
			modelBuilder.Entity<Join>().HasOne(e => e.User).WithMany(e => e.Joins).HasForeignKey(e => e.UserId).HasPrincipalKey(e => e.UserId);
			modelBuilder.Entity<Join>().HasOne(e => e.Subredis).WithMany(e => e.Joins).HasForeignKey(e => e.SubredisId).HasPrincipalKey(e => e.SubredisId);

			modelBuilder.Entity<Subredis>().HasOne(e => e.User).WithMany(e => e.Subredises).HasForeignKey(e => e.CreatedBy).HasPrincipalKey(e => e.UserId);


			modelBuilder.Entity<Post>().HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.CreatedBy).HasPrincipalKey(e => e.UserId);
		}
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
