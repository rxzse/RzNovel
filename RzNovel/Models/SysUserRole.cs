using System;
using System.Collections.Generic;

#nullable disable

namespace RzNovel.Models
{
    public partial class SysUserRole
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
