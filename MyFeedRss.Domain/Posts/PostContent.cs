using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.Posts;

public record PostContent : IPostContent
{
    public string Content { get; init; }

    public PostContent(string content)
    {
        Content = content;
    }

    public bool ContainsHtml() => new Regex(@"<[^>]+>").IsMatch(Content);

}
