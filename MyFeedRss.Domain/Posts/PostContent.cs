using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.Posts;

public class PostContent : IPostContent
{
    public string Content { get; init; }

    public PostContent(string content)
    {
        Content = content;
    }
    public bool IsContentHtml()
    {
        // FIXME
        if (Content.StartsWith("<p>"))
            return true;

        return false;
    }
}
