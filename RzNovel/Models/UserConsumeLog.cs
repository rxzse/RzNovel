using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class UserConsumeLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long Amount { get; set; }
        public byte ProductType { get; set; }
        public long? ProductId { get; set; }
        public string ProducName { get; set; }
        public long? ProducValue { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
