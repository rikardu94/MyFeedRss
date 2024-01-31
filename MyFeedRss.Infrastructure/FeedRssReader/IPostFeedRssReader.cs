using MyFeedRss.Domain.FeedsRss;
using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.FeedRss
{
    public interface IPostFeedRssReader
    {
        public List<IPost> GetPosts(IFeedRss feedRss);
    }
}
