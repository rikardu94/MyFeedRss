using MyFeedRss.Domain.FeedRss;
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

        public void SynchronizePostsFromFeedRss(IFeedRssIdentity idFeedRss)
        {
            List<IPost> posts = new(); // PostFeedRssReader.GetPostsFromDate(feedRss.DateLastPost); // FIXME

            if (posts is not null && posts.Count > 0)
            {
                PostRepository.AddNewPosts(posts);

                // feedRss.DateLastPost = posts.Max(x => x.PublicationDate); // FIXME
                // FeedRssRepository.Save(feedRss); // FIXME

                // FIXME
                // transaction bdd
            }
        }
    }
}
