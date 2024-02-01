namespace MyFeedRss.Domain.Posts;

public class Post : IPost
{
    public IPostIdentity Id { get; init; } = new PostIdentity();
    public string Title { get; set; } = string.Empty;
    public IPostContent? Description { get; set; }
    public IPostContent? Content { get; set; }
    public string Link { get; set; } = string.Empty;
    public DateTime? PublicationDate { get; set; }
}
