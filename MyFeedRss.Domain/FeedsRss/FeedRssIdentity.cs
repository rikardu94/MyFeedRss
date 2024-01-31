using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.FeedsRss;

public class FeedRssIdentity : IFeedRssIdentity
{
    public Guid TechnicalId { get; init; } = Guid.NewGuid();
    public int FunctionalId { get; set; }
}
