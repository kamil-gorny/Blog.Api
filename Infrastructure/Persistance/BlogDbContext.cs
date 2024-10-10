using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistance;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    internal DbSet<Post> Posts { get; set; }
}