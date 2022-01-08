using web.Models;
using Microsoft.EntityFrameworkCore;

namespace web.Data
{
    //public class ForumContext : IdentityDbContext<ApplicationUser>
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
        }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostReply> PostReplies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            modelBuilder.Entity<Post>().ToTable("Post");
            //modelBuilder.Entity<PostReply>().ToTable("PostReply");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}