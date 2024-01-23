using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFeedRss.Domain.Common;

namespace MyFeedRss.Domain.Posts;

public interface IPostIdentity : IIdentity<Guid, int>
{

}
