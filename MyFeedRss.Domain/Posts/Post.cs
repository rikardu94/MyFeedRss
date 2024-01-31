namespace MyFeedRss.Domain.Posts;

public class Post : IPost
{
    public IPostIdentity Id { get; init; } = new PostIdentity();
    public string Title { get; init; } = string.Empty;
    public IPostContent? Content { get; init; }
    public string Link { get; init; } = string.Empty;
    public DateTime? PublicationDate { get; init; }
}
