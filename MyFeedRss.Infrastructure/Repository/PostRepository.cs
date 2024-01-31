using MyFeedRss.Domain;
using MyFeedRss.Domain.FeedsRss;
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
        private List<IPost> listPostsTmp = new();

        public void AddNewPosts(List<IPost> posts)
        {
            // FIXME
            listPostsTmp = posts;
        }

        public List<IPost> GetPostsFromFeedRss(IFeedRssIdentity idFeedRss)
        {
            // FIXME
            return listPostsTmp;
        }
    }
}
