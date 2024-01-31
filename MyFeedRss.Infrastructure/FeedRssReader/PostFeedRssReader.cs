using MyFeedRss.Domain.FeedsRss;
using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            if (item.Links.Count > 0)
            {
                string content;

                if (item.Content is not null && item.Content.ToString() is not null)
                    content = item.Content.ToString()!;
                else
                    content = item.Summary.Text;
                
                ListReturn.Add(new Post
                {
                    Title = item.Title.Text,
                    Content = new PostContent(content),
                    Link = item.Links.First().Uri.AbsoluteUri,
                    PublicationDate = item.PublishDate.DateTime
                });
            }
        }

        return ListReturn;
    }
}
