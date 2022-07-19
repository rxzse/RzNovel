using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class AuthorIncome
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long BookId { get; set; }
        public DateTime IncomeMonth { get; set; }
        public long PreTaxIncome { get; set; }
        public long AfterTaxIncome { get; set; }
        public byte PayStatus { get; set; }
        public byte ConfirmStatus { get; set; }
        public string Detail { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
