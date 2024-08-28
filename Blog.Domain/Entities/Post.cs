namespace Blog.Domain.Entities;

public class Post
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime CreationDate { get; set; }
}