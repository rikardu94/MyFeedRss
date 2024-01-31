using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.Posts;

public interface IPost
{
    public IPostIdentity Id { get; init; }
    public string Title { get; init; }
    public IPostContent? Content { get; init; }
    public string Link { get; init; }
    public DateTime? PublicationDate { get; init; }
}
