using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class BookInfo
    {
        public long Id { get; set; }
        public byte? WorkDirection { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string PicUrl { get; set; }
        public string BookName { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BookDesc { get; set; }
        public byte Score { get; set; }
        public byte BookStatus { get; set; }
        public long VisitCount { get; set; }
        public long WordCount { get; set; }
        public long CommentCount { get; set; }
        public long? LastChapterId { get; set; }
        public string LastChapterName { get; set; }
        public DateTime? LastChapterUpdateTime { get; set; }
        public byte IsVip { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
