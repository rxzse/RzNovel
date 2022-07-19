using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class HomeFriendLink
    {
        public long Id { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public byte Sort { get; set; }
        public byte IsOpen { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
