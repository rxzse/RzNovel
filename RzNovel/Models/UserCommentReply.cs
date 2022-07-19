using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class UserCommentReply
    {
        public long Id { get; set; }
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public string ReplyContent { get; set; }
        public byte AuditStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
