namespace Blog.Application.DataModel;

public class CreatePostServiceRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime CreationDate { get; set; }
}