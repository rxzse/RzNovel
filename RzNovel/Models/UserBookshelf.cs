using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class UserBookshelf
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public long? PreContentId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
