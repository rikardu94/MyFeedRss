using MyFeedRss.Domain.FeedsRss;
using MyFeedRss.Domain.Posts;
using MyFeedRss.Infrastructure.FeedRss;
using MyFeedRss.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Application.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostFeedRssReader PostFeedRssReader;
        private readonly IPostRepository PostRepository;
        private readonly IFeedRssRepository FeedRssRepository;

        public PostService(IPostFeedRssReader postFeedRssReader, IFeedRssRepository feedRssRepository, IPostRepository postRepository)
        {
            PostFeedRssReader = postFeedRssReader;
            FeedRssRepository = feedRssRepository;
            PostRepository = postRepository;
        }

        public List<IPost> GetPostsFromFeedRss(IFeedRssIdentity idFeedRss)
        {
            return PostRepository.GetPostsFromFeedRss(idFeedRss);
        }

        public void SynchronizePostsFromFeedRss(IFeedRss feedRss)
        {
            DateTime lastUpdatedTime = DateTime.Now;

            List<IPost> posts = PostFeedRssReader.GetPosts(feedRss);

            PostRepository.AddNewPosts(posts);
            feedRss.LastUpdatedTime = lastUpdatedTime;

            FeedRssRepository.Save(feedRss);

            // FIXME
            // transaction bdd
        }
    }
}
