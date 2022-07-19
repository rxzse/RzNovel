using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class UserPayLog
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public byte PayChannel { get; set; }
        public string OutTradeNo { get; set; }
        public long Amount { get; set; }
        public byte ProductType { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public long? ProductValue { get; set; }
        public DateTime PayTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
