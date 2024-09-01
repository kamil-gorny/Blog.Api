using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly BlogDbContext _dbContext;

    public CommentRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Comment?> GetById(Guid id)
    {
        return await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Comment>> GetAll()
    {
        return await _dbContext.Comments.ToListAsync();
    }

    public async Task<Guid> Create(Comment comment)
    {
        await _dbContext.Comments.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
        return comment.Id;
    }
}