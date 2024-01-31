using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.FeedsRss;

public interface IFeedRss
{
    public IFeedRssIdentity Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }
    public bool SinceLastUpdatedTime { get; set; }
    public DateTime? LastUpdatedTime { get; set; }
}
