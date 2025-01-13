using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RequestHelpers
{
    public class Pagination<G>(int pageIndex, int pageSize, int count, IReadOnlyList<G> data) 
    {
        public int PageIndex { get; set; } =  pageIndex;
        public int PageSize { get; set; } =  pageSize;
        public int Count { get; set; }   =  count;
        public IReadOnlyList<G> Data { get; set; } =  data;
    }
}