using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class AuthorIncomeDetail
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public long BookId { get; set; }
        public DateTime IncomeDate { get; set; }
        public long IncomeAccount { get; set; }
        public long IncomeCount { get; set; }
        public long IncomeNumber { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
