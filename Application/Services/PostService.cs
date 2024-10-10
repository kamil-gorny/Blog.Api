using Application.DataModel;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

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
    
    public async Task<Guid> CreatePost(CreatePostServiceRequest createPostRequest)
    {
        var post = new Post
        {
            Id = new Guid(),
            Title = createPostRequest.Title,
            Content = createPostRequest.Content,
            CreationDate = createPostRequest.CreationDate
        };
        return await _postRepository.Create(post);
    }
    
    
}

public interface IPostService
{
    Task<Post?> GetPost(Guid id);
    Task<IEnumerable<Post>> GetPosts();
    Task<Guid> CreatePost(CreatePostServiceRequest createPostRequest);
}
