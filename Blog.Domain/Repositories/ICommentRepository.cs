using Blog.Domain.Entities;

namespace Blog.Domain.Repositories;

public interface ICommentRepository
{
    Task<Comment?> GetById(Guid id);
    Task<IEnumerable<Comment>> GetAll();
    Task<Guid> Create(Comment post);
}