using Blog.Application.DataModel;
using Blog.Domain.Entities;
using Blog.Domain.Repositories;

namespace Blog.Application.Services;

public class PostService : IPostService
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
    
    public async Task<Guid> CreatePost(PostServiceRequest postRequest)
    {
        var post = new Post
        {
            Id = new Guid(),
            Title = postRequest.Title,
            Content = postRequest.Content,
            CreationDate = postRequest.CreationDate
        };
        return await _postRepository.Create(post);
    }
    
    
}

public interface IPostService
{
    Task<Post?> GetPost(Guid id);
    Task<IEnumerable<Post>> GetPosts();
    Task<Guid> CreatePost(PostServiceRequest postRequest);
}
