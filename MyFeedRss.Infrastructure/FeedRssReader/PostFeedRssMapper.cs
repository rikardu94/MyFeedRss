using MyFeedRss.Domain.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyFeedRss.Infrastructure.FeedRssReader;

public static class PostFeedRssMapper
{
    public static IPost CreateFromFeedRssReader(SyndicationItem post)
    {
        IPost postReturn = new Post();

        postReturn.Title = post.Title.Text;
        postReturn.Description = new PostContent(post.Summary.Text);
        if (post.Links.Count > 0)
            postReturn.Link = post.Links.First().Uri.AbsoluteUri;
        postReturn.PublicationDate = post.PublishDate.DateTime;

        // content
        StringBuilder content = new StringBuilder();
        foreach (SyndicationElementExtension extension in post.ElementExtensions)
        {
            XElement ele = extension.GetObject<XElement>();
            if (ele.Name.LocalName == "encoded" && ele.Name.Namespace.ToString().Contains("content"))
            {
                content.Append(ele.Value + "<br/>");
            }
        }
        if (content.Length > 0)
            postReturn.Content = new PostContent(content.ToString());

        return postReturn;
    }
}
