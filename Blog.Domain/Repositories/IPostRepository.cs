using Blog.Domain.Entities;

namespace Blog.Domain.Repositories;

public interface IPostRepository
{
    Task<Post?> GetById(Guid id);
    Task<IEnumerable<Post>> GetAll();
    Task<Guid> Create(Post post);
}