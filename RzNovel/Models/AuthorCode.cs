using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class AuthorCode
    {
        public long Id { get; set; }
        public string InviteCode { get; set; }
        public DateTime ValidityTime { get; set; }
        public byte IsUsed { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
