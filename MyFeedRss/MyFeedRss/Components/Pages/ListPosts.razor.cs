using Microsoft.AspNetCore.Components;
using MyFeedRss.Application.FeedsRss;
using MyFeedRss.Application.Posts;
using MyFeedRss.Domain.FeedsRss;
using MyFeedRss.Domain.Posts;

namespace MyFeedRss.Components.Pages;

public partial class ListPosts
{
    [Parameter]
    public int FunctionalIdFeedRss { get; init; }

    [Inject]
    private IFeedRssService FeedRssService { get; init; } = default!;

    [Inject]
    private IPostService PostService { get; init; } = default!;

    private IFeedRss? FeedRssInfo { get; set; }
    private List<IPost> Posts { get; set; } = new();

    protected override Task OnInitializedAsync()
    {
        FeedRssInfo = FeedRssService.GetFeedRssByFunctionnalId(FunctionalIdFeedRss);
        if (FeedRssInfo is not null)
        {
            PostService.SynchronizePostsFromFeedRss(FeedRssInfo);
            Posts = PostService.GetPostsFromFeedRss(FeedRssInfo.Id);
        }

        return base.OnInitializedAsync();
    }
}
