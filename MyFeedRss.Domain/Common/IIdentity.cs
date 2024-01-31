using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.Common;

public interface IIdentity<TypeTechnical, TypeFunctional>
{
    public TypeTechnical TechnicalId { get; init; }

    public TypeFunctional FunctionalId { get; set; }
}
