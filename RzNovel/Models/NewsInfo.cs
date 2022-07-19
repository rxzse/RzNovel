using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class NewsInfo
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SourceName { get; set; }
        public string Title { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
