using MyFeedRss.Domain.FeedsRss;
using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.Repository
{
    public interface IPostRepository
    {
        public List<IPost> GetPostsFromFeedRss(IFeedRssIdentity idFeedRss);

        public void AddNewPosts(List<IPost> posts);
    }
}
