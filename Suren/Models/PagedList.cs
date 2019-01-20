using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suren.Models
{
    public class PagedList<T> : List<T>
    {
        public PagedList()
        {

        }
        public PagedList(List<T> list)
        {
            this.AddRange(list);
        }
        public PagedList<T> SetPageInfo(int pno, int pagesize, int totalcount)
        {
            this.TotalCount = Math.Max(0, totalcount);
            this.PageNo = Math.Max(0, pno);
            this.PageSize = Math.Max(0, pagesize);
            return this;
        }
        public int TotalCount { get; protected set; }
        public int PageNo { get; protected set; }
        public int PageSize { get; protected set; }
        public int TotalPage
        {
            get
            {
                if (this.PageSize == 0) return 1;
                if (this.TotalCount == 0) return 1;
                return this.TotalCount / this.PageSize + (this.TotalCount % this.PageSize == 0 ? 0 : 1);
            }
        }
    }
}
