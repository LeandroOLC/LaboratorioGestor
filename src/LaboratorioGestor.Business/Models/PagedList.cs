using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioGestor.Business.Models
{
    public class PagedList<T>
    {
        public PagedList()
        {
        }
        public PagedList(IList<T> source, int pageNumber, int pageSize)
        {
            this.TotalItems = source.Count;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Items = source;
        }

        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int TotalPages => (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);



    }
}
