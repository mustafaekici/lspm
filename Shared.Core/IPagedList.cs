using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core
{
    public interface IPagedList<T>
    {
        int PageSize { get; set; }
        int PageIndex { get; set; }
        int TotalCount { get; set; }
        int PageCount { get; set; }
        List<T> Items { get; set; }
    }
}
