using MyFeedRss.Domain.FeedsRss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.Repository;

public class FeedRssRepository : IFeedRssRepository
{
    private List<IFeedRss> ListReturn = new List<IFeedRss> {
            new Domain.FeedsRss.FeedRss { Id = { FunctionalId = 1 }, Name = "Plpware", Link = "https://pplware.sapo.pt/feed", SinceLastUpdatedTime = true },
            new Domain.FeedsRss.FeedRss { Id = { FunctionalId = 2 }, Name = "Korben", Link = "https://korben.info/feed" }
        }; // FIXME

    public List<IFeedRss> GetAllFeedRss()
    {
        // FIXME
        return ListReturn;
    }

    public IFeedRss? GetFeedRssByFunctionnalId(int id)
    {
        // FIXME
        return ListReturn.Where(x => x.Id.FunctionalId.Equals(id)).FirstOrDefault();
    }

    public void Save(IFeedRss feedRss)
    {
        // FIXME
        
    }
}
