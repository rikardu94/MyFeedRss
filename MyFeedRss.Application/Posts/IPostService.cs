using MyFeedRss.Domain.FeedRss;
using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Application.Posts;

public interface IPostService
{
    public List<IPost> GetPostsFromFeedRss(IFeedRssIdentity idFeedRss);

    public void SynchronizePostsFromFeedRss(IFeedRssIdentity idFeedRss);
}
