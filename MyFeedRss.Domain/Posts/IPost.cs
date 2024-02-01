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
    public string Title { get; set; }
    public IPostContent? Description { get; set; }
    public IPostContent? Content { get; set; }
    public string Link { get; set; }
    public DateTime? PublicationDate { get; set; }
}
