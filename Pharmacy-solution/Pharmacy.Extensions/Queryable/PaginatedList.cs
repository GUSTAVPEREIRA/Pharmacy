using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.Extensions.Queryable
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCounts { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCounts = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCounts / (double)pageSize);

            this.AddRange(source.Skip(pageIndex * pageSize).Take(pageSize));
        }

        public bool HasPreviusPage
        {
            get
            {
                return PageIndex > 0;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex + 1 < TotalPages;
            }
        }
    }
}