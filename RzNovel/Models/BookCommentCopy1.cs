using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class BookCommentCopy1
    {
        public long Id { get; set; }
        public long BookId { get; set; }
        public long UserId { get; set; }
        public string CommentContent { get; set; }
        public long ReplyCount { get; set; }
        public byte AuditStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
