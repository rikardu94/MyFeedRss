using MyFeedRss.Domain.FeedRss;
using MyFeedRss.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Application.FeedsRss;

public class FeedRssService : IFeedRssService
{
    private readonly IFeedRssRepository FeedRssRepository;

    public FeedRssService(IFeedRssRepository feedRssRepository)
    {
        FeedRssRepository = feedRssRepository;
    }

    public List<IFeedRss> GetAllFeedsRss()
    {
        return FeedRssRepository.GetAllFeedRss();
    }
}
