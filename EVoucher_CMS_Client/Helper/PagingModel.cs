using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EVoucher_CMS_Client.Helper
{
    public class PagingModel<T>
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public string prevLink { get; set; }
        public string nextLink { get; set; }
        public IPagedList<T> Results { get; set; }
    }
}

