using MyFeedRss.Domain;
using MyFeedRss.Domain.FeedRss;
using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        public void AddNewPosts(List<IPost> posts)
        {
            // FIXME
            
        }

        public List<IPost> GetPostsFromFeedRss(IFeedRssIdentity idFeedRss)
        {
            // FIXME
            return new List<IPost>
            {
                new Post { Title = "Post 1" },
                new Post { Title = "Post 2" },
                new Post { Title = "Post 3" }
            };
        }
    }
}
