using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RzNovel.Common.Resp
{
    public class PageRespDto<T>
    {
        public long pageNum { get; set; }

        public long pageSize { get; set; }

        public long total { get; set; }

        public List<T> list { get; set; }

        public PageRespDto(long pageNum, long pageSize, long total, List<T> list)
        {
            this.pageNum = pageNum;
            this.pageSize = pageSize;
            this.total = total;
            this.list = list;
        }

        public static PageRespDto<T> of(long pageNum, long pageSize, long total, List<T> list)
        {
            return new PageRespDto<T>(pageNum, pageSize, total, list);
        }

        public long getPages()
        {
            if (this.pageSize == 0L)
            {
                return 0L;
            }
            else
            {
                long pages = this.total / this.pageSize;
                if (this.total % this.pageSize != 0L)
                {
                    ++pages;
                }
                return pages;
            }
        }
    }
}
