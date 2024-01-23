using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.Posts;

public class PostIdentity : IPostIdentity
{
    public Guid TechnicalId { get; init; } = Guid.NewGuid();
    public int FunctionalId { get; init; }
}
