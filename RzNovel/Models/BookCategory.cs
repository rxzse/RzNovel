using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class BookCategory
    {
        public long Id { get; set; }
        public byte WorkDirection { get; set; }
        public string Name { get; set; }
        public byte Sort { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
