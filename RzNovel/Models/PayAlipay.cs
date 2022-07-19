using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class PayAlipay
    {
        public long Id { get; set; }
        public string OutTradeNo { get; set; }
        public string TradeNo { get; set; }
        public string BuyerId { get; set; }
        public string TradeStatus { get; set; }
        public long TotalAmount { get; set; }
        public long? ReceiptAmount { get; set; }
        public long? InvoiceAmount { get; set; }
        public DateTime? GmtCreate { get; set; }
        public DateTime? GmtPayment { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
