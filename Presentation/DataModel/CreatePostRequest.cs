namespace Application.DataModel;

public class CreatePostRequest
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required DateTime CreationDate { get; set; }
}