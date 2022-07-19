using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class AuthorInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string InviteCode { get; set; }
        public string PenName { get; set; }
        public string TelPhone { get; set; }
        public string ChatAccount { get; set; }
        public string Email { get; set; }
        public byte? WorkDirection { get; set; }
        public byte Status { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
