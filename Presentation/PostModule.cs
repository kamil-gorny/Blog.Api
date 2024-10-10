using Application.DataModel;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;


public static class PostModule
{
    public static void AddPostEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/posts", async (IPostService postService) =>
        {
            var posts = await postService.GetPosts();
            return Results.Ok(posts);
        });
        
        endpoints.MapGet("/posts/{id}", async (Guid id, IPostService postService) =>
        {
            var post = await postService.GetPost(id);
            if (post == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(post);
        });
        
        endpoints.MapPost("/posts", async (CreatePostRequest createPostRequest, IPostService postService) =>
        {
            var createPostServiceRequest = new CreatePostServiceRequest
            {
                Title = createPostRequest.Title,
                Content = createPostRequest.Content,
                CreationDate = createPostRequest.CreationDate
            };
            var postId = await postService.CreatePost(createPostServiceRequest);
            return Results.Created($"/posts/{postId}", postId);
        });
    }
}