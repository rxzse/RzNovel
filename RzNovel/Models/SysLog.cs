using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class SysLog
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string Username { get; set; }
        public string Operation { get; set; }
        public long? Time { get; set; }
        public string Method { get; set; }
        public string Params { get; set; }
        public string Ip { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
