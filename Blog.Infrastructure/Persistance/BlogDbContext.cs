using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistance;

internal class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    internal DbSet<Post> Posts { get; set; }
    internal DbSet<Comment> Comments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Post>().HasMany(p => p.Comments).WithOne().HasForeignKey(c => c.PostId);
    }
}