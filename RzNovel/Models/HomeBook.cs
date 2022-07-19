using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class HomeBook
    {
        public long Id { get; set; }
        public byte Type { get; set; }
        public byte Sort { get; set; }
        public long BookId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
