using MyFeedRss.Domain.FeedsRss;
using MyFeedRss.Domain.Posts;
using MyFeedRss.Infrastructure.FeedRssReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MyFeedRss.Infrastructure.FeedRss;

public class PostFeedRssReader : IPostFeedRssReader
{
    public List<IPost> GetPosts(IFeedRss feedRss)
    {
        if (feedRss.SinceLastUpdatedTime)
            return GetPostsSinceLastUpdatedTime(feedRss);
        
        return GetPostsFromPage(feedRss.Link, 1);
    }

    private List<IPost> GetPostsSinceLastUpdatedTime(IFeedRss feedRss)
    {
        DateTime? lastUpdatedTime;
        var listPostsResult = new List<IPost>();
        var currentPage = 1;
        var havePostsToGet = true;

        if (feedRss.LastUpdatedTime is null)
            lastUpdatedTime = DateTime.Now.AddDays(-1);
        else
            lastUpdatedTime = feedRss.LastUpdatedTime;

        while (havePostsToGet)
        {
            var postsCurrentPage = GetPostsFromPage(feedRss.Link, currentPage);

            // add new posts to return list
            listPostsResult.AddRange(postsCurrentPage.Where(x => x.PublicationDate > lastUpdatedTime).ToList());

            // check if there are new posts to get
            havePostsToGet = postsCurrentPage.Where(x => x.PublicationDate <= lastUpdatedTime).Count() == 0;

            currentPage++;
        }

        return listPostsResult;
    }

    private List<IPost> GetPostsFromPage(string url, int page)
    {
        List<IPost> ListReturn = new();
        string urlCompleted;

        // generates completed URL
        urlCompleted = url;
        if (page > 1)
        {
            if (!url.EndsWith("/"))
                urlCompleted += "/";
            urlCompleted += "?paged="+page;
        }

        // get information from Feed Rss
        XmlReader reader = XmlReader.Create(urlCompleted);
        SyndicationFeed feed = SyndicationFeed.Load(reader);
        reader.Close();
        foreach (SyndicationItem item in feed.Items)
        {
            ListReturn.Add(PostFeedRssMapper.CreateFromFeedRssReader(item));
        }

        return ListReturn;
    }
}
