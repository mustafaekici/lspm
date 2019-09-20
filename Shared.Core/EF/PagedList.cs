using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public class PagedList<TEntity, PKType> : IDisposable
          where TEntity : IEntity<PKType>
          where PKType : IComparable
    {
        public int PageSize { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalRecordCount { get; private set; }
        public int PageCount { get; set; }
        public List<TEntity> CurrentPageItems { get; private set; }

        public PagedList(List<TEntity> currentPageItems, int pageIndex, int pageSize, int totalRecordCount)
        {
            CurrentPageItems = currentPageItems;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalRecordCount = totalRecordCount;
            PageCount = (int)Math.Ceiling(totalRecordCount / (double)pageSize);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                CurrentPageItems = null;
                disposedValue = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
