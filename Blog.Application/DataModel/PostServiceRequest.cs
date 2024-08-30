namespace Blog.Application.DataModel;

public class PostServiceRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime CreationDate { get; set; }
}