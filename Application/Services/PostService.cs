using Application.DataModel;
using Application.Extensions;
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
        return await _postRepository.GetByIdAsync(id);
    }
    
    public async Task<IEnumerable<Post>> GetPosts()
    {
        return await _postRepository.GetAllAsync();
    }
    
    public async Task<Guid> CreatePost(CreatePostServiceRequest createPostRequest)
    {
        var post = new Post
        {
            Id = new Guid(),
            Slug = createPostRequest.Title.ToSlug(),
            Title = createPostRequest.Title,
            Content = createPostRequest.Content,
            CreationDate = DateTime.Now
        };
        return await _postRepository.CreateAsync(post);
    }
    
    
}

public interface IPostService
{
    Task<Post?> GetPost(Guid id);
    Task<IEnumerable<Post>> GetPosts();
    Task<Guid> CreatePost(CreatePostServiceRequest createPostRequest);
}
