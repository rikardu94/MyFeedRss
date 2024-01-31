using MyFeedRss.Domain.FeedsRss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Infrastructure.Repository;

public interface IFeedRssRepository
{
    public List<IFeedRss> GetAllFeedRss();

    public IFeedRss? GetFeedRssByFunctionnalId(int id);

    public void Save(IFeedRss feedRss);
}
