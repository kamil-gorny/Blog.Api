using Domain.Entities;

namespace Domain.Repositories;

public interface IPostRepository
{
    Task<Post?> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Guid> CreateAsync(Post post);
}