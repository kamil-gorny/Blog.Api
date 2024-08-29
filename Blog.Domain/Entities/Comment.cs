namespace Blog.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public Guid PostId { get; set; }
    public DateTime CreationDate { get; set; }
}