namespace Application.DataModel;

public class CreatePostServiceRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
}