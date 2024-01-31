using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.FeedsRss;

public class FeedRss : IFeedRss
{
    public IFeedRssIdentity Id { get; set; } = new FeedRssIdentity();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public bool SinceLastUpdatedTime { get; set; }
    public DateTime? LastUpdatedTime { get; set; }
}
