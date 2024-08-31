using Blog.Api.DataModel;
using Blog.Application.DataModel;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    
    public async Task<IActionResult> GetPost(Guid id)
    {
        var post = await _postService.GetPost(id);
        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }
    
    public async Task<IActionResult> GetPosts()
    {
        var posts = await _postService.GetPosts();
        return Ok(posts);
    }
    
    public async Task<IActionResult> CreatePost(CreatePostRequest postRequest)
    {
        var post = new PostServiceRequest()
        {
            Title = postRequest.Title,
            Content = postRequest.Content,
            CreationDate = postRequest.CreationDate
        };
        
        var postId = await _postService.CreatePost(post);
        return CreatedAtAction(nameof(GetPost), new { id = postId }, null);
    }
}