using Blog.Domain.Entities;

namespace Blog.Domain.Repositories;

public interface ICommentRepository
{
    Task<Comment?> GetByIdAsync(Guid id);
    Task<IEnumerable<Comment>> GetAllAsync();
    Task<Guid> CreateAsync(Comment post);
}