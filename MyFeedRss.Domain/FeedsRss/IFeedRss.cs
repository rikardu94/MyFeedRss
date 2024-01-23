using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.FeedRss;

public interface IFeedRss
{
    public IFeedRssIdentity Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
}
