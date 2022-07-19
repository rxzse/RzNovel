using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class SysMenu
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public byte Type { get; set; }
        public string Icon { get; set; }
        public byte? Sort { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
