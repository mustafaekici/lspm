using Shared.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts
{
    public class PagedList<T> : IPagedList<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public List<T> Items { get; set; }

        public PagedList()
        {

        }

        public PagedList(List<T> currentPageItems, int pageIndex, int pageSize, int totalRecordCount)
        {
            Items = currentPageItems;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalRecordCount;
            PageCount = (int)Math.Ceiling(totalRecordCount / (double)pageSize);
        }
    }

    public class SearchBase
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string Sort { get; set; }
    }
}
