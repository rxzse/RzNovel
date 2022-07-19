using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class BookChapter
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public int ChapterNum { get; set; }
        public string ChapterName { get; set; }
        public long WordCount { get; set; }
        public byte IsVip { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
