using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedRss.Domain.Posts;

public interface IPostContent
{
    public string Content { get; init; }
    public bool IsContentHtml();
    public bool IsImagePresent();
}
