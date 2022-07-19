using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class UserFeedback
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
