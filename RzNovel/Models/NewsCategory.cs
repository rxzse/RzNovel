using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class NewsCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public byte Sort { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
