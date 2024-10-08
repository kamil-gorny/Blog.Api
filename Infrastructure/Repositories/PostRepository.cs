using Domain.Entities;
using Domain.Repositories;
using Blog.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogDbContext _dbContext;

    public PostRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Post?> GetByIdAsync(Guid id)
    { 
        return _dbContext.Posts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var posts= await _dbContext.Posts.ToListAsync();
        return posts;
    }

    public async Task<Guid> CreateAsync(Post post)
    {
        await _dbContext.Posts.AddAsync(post);
        await _dbContext.SaveChangesAsync();
        return post.Id;
    }
}