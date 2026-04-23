using BlogModules.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogModules.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> option) : base(option)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Post>(post =>
        //     {
        //         post.ToTable("Posts", "Blog");
        //
        //         post.HasKey(x => x.Id);
        //
        //         post.HasIndex(x => x.Slug);
        //         post.Property(x => x.Slug)
        //         .HasMaxLength(80)
        //         .IsUnicode(true);
        //
        //         post.Property(x => x.Title)
        //         .HasMaxLength(80);
        //
        //         post.Property(x => x.OwnerName)
        //         .HasMaxLength(80);
        //         post.Property(x => x.ImageName)
        //         .HasMaxLength(110);
        //
        //     });
        //     modelBuilder.Entity<Category>(category =>
        //     {
        //         category.ToTable("Categories", "dbo.Blog");
        //
        //         category.HasKey(x => x.Id);
        //
        //         category.HasIndex(x => x.Slug);
        //         category.Property(x => x.Slug)
        //         .HasMaxLength(80)
        //         .IsUnicode(true);
        //
        //     });
        //     
        //     base.OnModelCreating(modelBuilder);
        // }

    }
}
