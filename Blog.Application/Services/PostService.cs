using Blog.Domain.Entities;
using Blog.Domain.Repositories;

namespace Blog.Application.Services;

public class PostService
{
    private readonly IPostRepository _postRepository;
    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Post?> GetPost(Guid id)
    {
        return await _postRepository.GetById(id);
    }
    
    public async Task<IEnumerable<Post>> GetPosts()
    {
        return await _postRepository.GetAll();
    }
    
    public async Task<Guid> CreatePost(Post post)
    {
        return await _postRepository.Create(post);
    }
    
    
}
