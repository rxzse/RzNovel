using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class PayWechat
    {
        public long Id { get; set; }
        public string OutTradeNo { get; set; }
        public string TransactionId { get; set; }
        public string TradeType { get; set; }
        public string TradeState { get; set; }
        public string TradeStateDesc { get; set; }
        public long Amount { get; set; }
        public long? PayerTotal { get; set; }
        public DateTime? SuccessTime { get; set; }
        public string PayerOpenid { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
