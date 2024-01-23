using MyFeedRss.Domain.FeedRss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Application.FeedsRss;

public interface IFeedRssService
{
    public List<IFeedRss> GetAllFeedsRss();
}
