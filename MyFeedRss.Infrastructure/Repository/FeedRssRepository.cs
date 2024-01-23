using MyFeedRss.Domain.FeedRss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.Repository;

public class FeedRssRepository : IFeedRssRepository
{
    public List<IFeedRss> GetAllFeedRss()
    {
        // FIXME
        return new List<IFeedRss> {
            new Domain.FeedRss.FeedRss { Name = "Flux RSS 1" },
            new Domain.FeedRss.FeedRss { Name = "Flux RSS 2" }
        };
    }

    public void Save(IFeedRss feedRss)
    {
        // FIXME
        throw new NotImplementedException();
    }
}
