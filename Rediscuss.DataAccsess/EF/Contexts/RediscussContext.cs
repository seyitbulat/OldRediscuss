using Microsoft.EntityFrameworkCore;
using Rediscuss.Model.Entities;

namespace Rediscuss.DataAccsess.EF.Contexts
{
    public class RediscussContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostImage>().HasKey("PostId");

            modelBuilder.Entity<Friend>().HasKey("FriendId", "UserId");

           // modelBuilder.Entity<User>().HasMany(e => e.Friends).WithOne(e => e.User).HasForeignKey(e => e.UserId).HasPrincipalKey(e => e.UserId);


            modelBuilder.Entity<Join>()
                .HasKey("UserId", "SubredisId");
            modelBuilder.Entity<Join>().HasOne(e => e.User).WithMany(e => e.Joins).HasForeignKey(e => e.UserId).HasPrincipalKey(e => e.UserId);
            modelBuilder.Entity<Join>().HasOne(e => e.Subredis).WithMany(e => e.Joins).HasForeignKey(e => e.SubredisId).HasPrincipalKey(e => e.SubredisId);


            modelBuilder.Entity<Subredis>().HasOne(e => e.User).WithMany(e => e.Subredises).HasForeignKey(e => e.CreatedBy).HasPrincipalKey(e => e.UserId);
            modelBuilder.Entity<Subredis>().HasMany(e => e.Posts).WithOne(e => e.Subredis).HasForeignKey(e => e.SubredisId).HasPrincipalKey(e => e.SubredisId);
            modelBuilder.Entity<Subredis>().HasMany(e => e.Joins).WithOne(e => e.Subredis).HasForeignKey(e => e.SubredisId).HasPrincipalKey(e => e.SubredisId);



            modelBuilder.Entity<Post>().HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.CreatedBy).HasPrincipalKey(e => e.UserId);
            modelBuilder.Entity<Post>().HasOne(e => e.Subredis).WithMany(e => e.Posts).HasForeignKey(e => e.SubredisId).HasPrincipalKey(e => e.SubredisId);
            modelBuilder.Entity<Post>().HasMany(e => e.PostImages).WithOne(e => e.Post).HasForeignKey(e => e.PostId).HasPrincipalKey(e => e.PostId);

            modelBuilder.Entity<PostImage>().HasOne(e => e.Post).WithMany(e => e.PostImages).HasForeignKey(e => e.PostId).HasPrincipalKey(e => e.PostId);


            modelBuilder.Entity<Comment>().HasOne(e => e.User).WithMany(e => e.Comments).HasForeignKey(e => e.CreatedBy).HasPrincipalKey(e => e.UserId);
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
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Friend> Friends { get; set; }

    }
}
