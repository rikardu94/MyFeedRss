using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.FeedRss;

public class PostFeedRssReader : IPostFeedRssReader
{
    public List<IPost> GetPostsFromDate(DateTime fromDateTime)
    {
        var listPostsResult = new List<IPost>();
        var currentPage = 1;
        var havePostsToGet = true;

        while (havePostsToGet)
        {
            var postsCurrentPage = GetPostsFromPage(currentPage);

            // add new posts to return list
            listPostsResult.AddRange(postsCurrentPage.Where(x => x.PublicationDate > fromDateTime).ToList());

            // check if there are new posts to get
            havePostsToGet = postsCurrentPage.Where(x => x.PublicationDate <= fromDateTime).Count() == 0;

            currentPage++;
        }
        
        return listPostsResult;
    }

    private List<IPost> GetPostsFromPage(int page)
    {
        // FIXME

        return new List<IPost>();
    }
}
